using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Key : MonoBehaviour
{
    public ChangeScene pipe;
    public AudioClip chewSound;
    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audiosource.PlayOneShot(chewSound, 0.3f);
            collision.transform.GetComponent<PlatformerCharacter2D>().Drugs();
            pipe.Activation();
            gameObject.SetActive(false);
        }
    }
}
