using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sheauriken : MonoBehaviour
{
    

  

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<SheaurikenAbility>().enabled = true;
            Destroy(gameObject);
           
        }
    }
}
