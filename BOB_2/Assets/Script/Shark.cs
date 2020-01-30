using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Shark : MonoBehaviour
{
    GameObject player;
    public GameObject death;
    Vector3 target;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x >= -4)
        {
            transform.localScale = new Vector3(-3f, 3, 3f);
        }
        else
        {
            transform.localScale = new Vector3(3f, 3f, 3f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("fjilsdfjjkdf");
            collision.transform.GetComponent<PlatformerCharacter2D>().Lose();
        }

        if (collision.transform.CompareTag("Sheauriken"))
        {
            Instantiate(death, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
