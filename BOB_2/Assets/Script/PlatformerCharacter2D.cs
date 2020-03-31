using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(Platformer2DUserControl))]
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] float airSpeed;
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        [SerializeField] const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        public bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
        public int health = 1;
        private SpriteRenderer sr; 
        
        public KeyCode jumpTouch;



        private void Awake()
        {
            // Setting up references.
            //DontDestroyOnLoad(this.gameObject);
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }





            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

        }


        public void Move(float move, bool crouch, bool jump)
        {

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move * m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

                if (move > 0 && !m_FacingRight)
                {
                    Flip();
                }
                else if (move < 0 && m_FacingRight)
                {
                    Flip();
                }
            }

            // D�placement a�riens
            if (!m_Grounded && m_AirControl)
            {
                move = (crouch ? move * m_CrouchSpeed : move);

                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                m_Rigidbody2D.velocity = new Vector2(move * airSpeed, m_Rigidbody2D.velocity.y);

                if (move > 0 && !m_FacingRight)
                {
                    Flip();
                }
                else if (move < 0 && m_FacingRight)
                {
                    Flip();
                }
            }

            // Saut
            if (m_Grounded && jump)
            {
                m_Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                m_Anim.Play("Jump");
            }

        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            sr.flipX = !sr.flipX;
        }


        //Lorsque le joueur touche un ennemi
        public void Lose()
        {
            health--;

            if (health <= 0)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }

        //Utilisation des algues pour r�duire la vitesse
        public void Slow()
        {
            m_MaxSpeed = 3f;
        }

        //Reprise de la vitesse normale du personnage
        public void SetNormalSpeed()
        {
            m_MaxSpeed = 6f;
        }

        //Pour que le joueur reste sur la plateforme sans en tomber lorsqu'elle bouge
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Platform")
            {
                transform.parent = collision.transform;
            }
        }

        //Pour que le joueur continue de bouger apr�s avoir saut� de la plateforme sans en d�pendre
        public void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Platform")
            {
                transform.parent = null;
            }
        }
        public void Drugs()
        {
            m_MaxSpeed = m_MaxSpeed - 0.3f;
            transform.localScale = new Vector3(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f, transform.localScale.z);
            print("test");
        }
    }
}
