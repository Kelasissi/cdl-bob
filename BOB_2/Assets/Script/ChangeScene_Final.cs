using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_Final : MonoBehaviour
{

    private int nextSceneToLoad;
    public bool activated = false;

    private void Start()
    {
        nextSceneToLoad = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && activated == true)
        {
            SceneManager.LoadScene(nextSceneToLoad);
            // Monter la scale du perso
            // Baisser sa vitesse et la force de son saut.
        }

    }
}
