using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Key : MonoBehaviour
{
    public ChangeScene pipe;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.GetComponent<PlatformerCharacter2D>().Drugs();
            pipe.Activation();
            gameObject.SetActive(false);
        }
    }
}
