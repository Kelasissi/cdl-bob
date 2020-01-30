using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menuGroup;
    public bool menuFlag = true;

    private void Start()
    {
        DisableMenu();
    }

    public void ActivateOrDisableMenuGroup()
    {


        menuFlag = !menuFlag;
        if (menuFlag)
        {
            DisableMenu();
        }
        else
        {
            ActivateMenu();
        }

    }

    public void ActivateMenu()
    {
        menuGroup.SetActive(true);
        Time.timeScale = 0;
    }

    public void DisableMenu()
    {
        menuGroup.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
