using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Bandit : MonoBehaviour {
    private Animator            m_animator;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;
    private GameObject player;
    public GameObject explosion;


    public float speed;
    private float auxSpeed;
    private bool movingRight = false;
    private bool attacking = false;
    private bool hasAttacked = false;
    public Transform groundDetection;
    public Transform playeDetection;
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void KillPlayer()
    {
        GameObject e = Instantiate(explosion) as GameObject;
        e.transform.position = player.transform.position;
        Destroy(player);
        Invoke("RestartScene", 2);
    }

    void Start () {
        //Everything is being instantiated here
        m_animator = GetComponent<Animator>();
        GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        auxSpeed = speed;
        player = GameObject.Find("Knight");
    }

    bool AnimatorIsPlaying()
    {
        //This function just checks whether an animation is currently playing 
        return m_animator.GetCurrentAnimatorStateInfo(0).length >
               m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    bool AnimatorIsPlaying(string stateName)
    {
        //This is an overload of the above function, checking for the animation's name
        return AnimatorIsPlaying() && m_animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the bandit has been hit by the blade, he is destroyed 
        if (collision.name == "Blade")
        {
            Debug.Log("Enemy Killed");
            m_isDead = true;
        }
    }

    // Update is called once per frame
    void Update () {
        attacking = false;
        //Two rays project from the bandit, one in front, to check if the 
        //player is in melee range, and one downwards, to check if the bandit
        //has reached the end of the platform he's walking on
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, (float)0.08);
        RaycastHit2D playerInMeleeRange = Physics2D.Raycast(playeDetection.position, Vector2.left, (float)0.5);
        //The motion is started here
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
        if (playerInMeleeRange.collider == true)
        {
            //If the player has been detected, the bandit attacks
            Debug.Log("Player spotted");
            attacking = true;
            if(!hasAttacked)
                m_animator.Play("Attack");
            if (!AnimatorIsPlaying("Attack"))
            {
                KillPlayer();
                Debug.Log("Player Hit");
            }
            speed = 0;
        }
        if (!attacking)
        {
            hasAttacked = false;
            //The running animation is started here
            m_animator.SetInteger("AnimState", 2);
            speed = auxSpeed;
            if (groundInfo.collider == false)
            {
                //Here we switch the bandit's patrol direction
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

            //Check if the bandit is on the ground
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
    }
}
