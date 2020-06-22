using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Events;

public class Enemy_Ai : MonoBehaviour
{
    public Transform target;
    public float speed = 200;
    public float nextWayPointDistance = 3f;

    Path path;
    int currentWayPoint = 0;
    bool reachEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.

    [SerializeField] private Transform blockCheck;
    [SerializeField] private Transform emptyPlatformCheck;

    //public Canvas healthbar;
    //public Canvas staminaBar;

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    private bool blocked;               // Whether or not the player is facing a block. 
    private bool emptyPlatform;         // Whether or not the platform infrount is empty.

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("updatePath", 0f, .5f);
    }

    void updatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, onPathComplete);
        }
    }

    void onPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

        blocked = false;
        // The player is blocked if a circlecast to the blockCheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] faceBlockColliders = Physics2D.OverlapCircleAll(blockCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < faceBlockColliders.Length; i++)
        {
            if (faceBlockColliders[i].gameObject != gameObject)
            {
                blocked = true;
            }
        }

        emptyPlatform = false;
        Collider2D[] emptyPlatformColliders = Physics2D.OverlapCircleAll(emptyPlatformCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject == null)
            {
                emptyPlatform = true;
            }
        }

        if (path == null)
            return;

        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachEndOfPath = true;
            return;
        }
        else
        {
            reachEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        float hightDetector = path.vectorPath[currentWayPoint].y - rb.position.y;

        // If the Ai should jump...
        if (hightDetector > 0)
        {
            if ((m_Grounded && blocked) || (m_Grounded && emptyPlatform))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                rb.AddForce(new Vector2(0f, m_JumpForce));
                //animator.SetBool("Jumping", true);
            }
        }

        rb.AddForce(force);
        //animator.SetFloat("speed", force.x);

        // If the input is moving the player right and the player is facing left...
        if (direction.x > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (direction.x < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        transform.Rotate(0f, 180f, 0f);
        //healthbar.transform.Rotate(0f, 180f, 0f);
        //staminaBar.transform.Rotate(0f, 180f, 0f);
    }

    public void OnLanding()
    {
        //animator.SetBool("Jumping", false);
    }

}

