using UnityEngine;
using System.Collections;

public class Bandit : MonoBehaviour {

    //[SerializeField] float      m_speed = 1.0f;
    //[SerializeField] float      m_jumpForce = 2.0f;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;


    public float speed;
    private float auxSpeed;
    private bool movingRight = false;
    private bool attacking = false;
    public Transform groundDetection;
    public Transform playeDetection;
    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        auxSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Blade")
        {
            Debug.Log("Enemy Killed");
            m_animator.SetTrigger("Hurt");
            m_animator.SetTrigger("Death");
            m_isDead = true;
        }
    }

    // Update is called once per frame
    void Update () {
        //Check if character just landed on the ground
        if (!m_isDead)
        {
            attacking = false;
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, (float)0.08);
            RaycastHit2D playerInMeleeRange = Physics2D.Raycast(playeDetection.position, Vector2.left, (float)0.5);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (playerInMeleeRange.collider == true)
            {
                Debug.Log("Player spotted");
                attacking = true;
                speed = 0;
            }
            if(attacking)
                m_animator.SetTrigger("Attack");
            if (!attacking)
            {
                m_animator.SetInteger("AnimState", 2);
                speed = auxSpeed;
                if (groundInfo.collider == false)
                {
                    if (movingRight == true)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        movingRight = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingRight = true;
                    }
                }
            }

            if (!m_grounded && m_groundSensor.State())
            {
                m_grounded = true;
                m_animator.SetBool("Grounded", m_grounded);
            }

            //Check if character just started falling
            if (m_grounded && !m_groundSensor.State())
            {
                m_grounded = false;
                m_animator.SetBool("Grounded", m_grounded);
            }
        }

        // -- Handle input and movement --
        /*
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Move
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("e")) {
            if(!m_isDead)
                m_animator.SetTrigger("Death");
            else
                m_animator.SetTrigger("Recover");

            m_isDead = !m_isDead;
        }

        //Hurt
        else if (Input.GetKeyDown("q"))
            m_animator.SetTrigger("Hurt");

        //Attack
        else if(Input.GetMouseButtonDown(0)) {
            m_animator.SetTrigger("Attack");
        }

        //Change between idle and combat idle
        else if (Input.GetKeyDown("f"))
            m_combatIdle = !m_combatIdle;

        //Jump
        else if (Input.GetKeyDown("space") && m_grounded) {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
        */
    }
}
