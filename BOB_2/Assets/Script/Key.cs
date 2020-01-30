using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.parent = collision.transform;
            transform.localPosition = Vector2.zero;
            //Debug.Log(transform.position);
        }

        else if (collision.tag == "Door")
        {
            collision.GetComponent<ChangeScene>().activated = true;
            Debug.Log(0);
        }
    }
}
