using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour{

    private int nextSceneToLoad;
    public bool activated = false;
    public Sprite newSprite;

    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && activated == true)
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }

    }
    public void Activation()
    {
        activated = true;
    }

    private void Update()
    {
        if (activated == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
}
