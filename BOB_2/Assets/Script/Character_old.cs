using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Character : MonoBehaviour{
public float speed = 1f;
public float jumph = 1f;
public int health = 1;
public Animator animator;
public Transform transformRender;



    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dp = new Vector3();

        if (Input.GetKey(KeyCode.Q))
        {
            dp.x -= speed;
            transformRender.localScale = new Vector3(-Mathf.Abs(transformRender.localScale.x), transformRender.localScale.y, transformRender.localScale.z);
            animator.Play("Run");

        }

        if (Input.GetKey(KeyCode.D))
        {
            dp.x += speed;
            transformRender.localScale = new Vector3(Mathf.Abs(transformRender.localScale.x), transformRender.localScale.y, transformRender.localScale.z);
            animator.Play("Run");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            dp.y += jumph;
            animator.Play("Jump");
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            animator.Play("Idle");
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.Play("Idle");
        }

        

        transform.position += dp;



  
    }

    public void Lose()
    {
        health--;

        if (health <= 0)
        {
            //    Destroy(gameObject);
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

         //   StartCoroutine(WaitAndLose());
        }
    }

 //   IEnumerator WaitAndLose()
 //   {
 //       yield return new WaitForSeconds(2);
 //   }

          
}

