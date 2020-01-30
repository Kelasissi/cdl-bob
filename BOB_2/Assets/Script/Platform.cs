using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    [SerializeField] bool isVertical = false;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position || transform.position == startPos.position)
        {
            nextPos = pos2.position;
            if (!isVertical)
                Flip();
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
            if (!isVertical)
                Flip();
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
    /*private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }*/

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
