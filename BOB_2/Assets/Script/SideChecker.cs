using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideChecker : MonoBehaviour
{
    bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Détermine si le joueur se trouve en face d'un mur
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Algue") == false) { 
            isColliding = true;
        }
    }

    //Détermine si le joueur ne se trouve plus en face d'un mur
    void OnTriggerExit2D(Collider2D other)
    {
        isColliding = false;
    }

    //Permet de renvoyer si le joueur est en collision avec un mur
    public bool IsColliding()
    {
        return isColliding;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
