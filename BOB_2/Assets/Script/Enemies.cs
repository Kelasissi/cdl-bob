using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    public GameObject death;


    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position== pos1.position)
        {
            nextPos = pos2.position;
            turnAround();
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
            turnAround();

        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlatformerCharacter2D>().Lose();
        }

        if (collision.transform.CompareTag("Sheauriken"))
        {
            Instantiate(death, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    void turnAround()
    {
        if (transform.localScale.x == 5)
        {
            transform.localScale = new Vector3(-5f, 5f, 5f);
        }
        else
        {
            transform.localScale = new Vector3(5f, 5f, 5f);
        }
    }
}
