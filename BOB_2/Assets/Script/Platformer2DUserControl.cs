using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public bool m_Grounded;

        private int nextSceneToLoad;

        public KeyCode jumpTouch;
        public KeyCode leftTouch;
        public KeyCode rightTouch;
        public KeyCode resetTouch;
        public KeyCode quitTouch;
        public KeyCode nextTouch;
        public AudioClip jump;
        AudioSource audioSource;

        public SideChecker sideCheckerLeftScript;
        public SideChecker sideCheckerRightScript;

        private void Start()
        {
            nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        }

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            audioSource = GetComponent<AudioSource>();
        }


        private void Update()
        {
            /*if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                m_Jump = Input.GetKey(jumpTouch) ;
                audioSource.PlayOneShot(jump, 0.2F);
                 }*/

            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                m_Jump = Input.GetKey(jumpTouch);
            }

            if (Input.GetKeyDown(jumpTouch) && !m_Grounded)
            {
                audioSource.PlayOneShot(jump, 0.2F);
            }

            if (Input.GetKeyDown(resetTouch))
            {
                GetComponent<PlatformerCharacter2D>().Lose();
            }

            if (Input.GetKey(quitTouch))
            {
                Application.Quit();
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = 0;

            if (Input.GetKey(leftTouch) && sideCheckerLeftScript.IsColliding() == false)
            {
                h = -1;
            }

            if (Input.GetKey(rightTouch) && sideCheckerRightScript.IsColliding() == false)
            {
                h = 1;
            }

            if (Input.GetKey(nextTouch))
            {
                SceneManager.LoadScene(nextSceneToLoad);
            }


            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
