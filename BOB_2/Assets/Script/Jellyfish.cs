using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    [SerializeField] float bounceForce;
    Animator jellyfishAnimator;

    public AudioClip bounce;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        jellyfishAnimator = gameObject.GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounceForce));
            jellyfishAnimator.SetBool("bouncing", true);
            audiosource.PlayOneShot(bounce, 0.3f);
        }
    }

    public void Bounce()
    {
        jellyfishAnimator.SetBool("bouncing", false);
    }
}
