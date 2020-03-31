using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Narrateur2 : MonoBehaviour
{
    public float startTalk;
    public float letterPause = 0.1f;
    string message;
    TextMeshPro textComp;

    // Use this for initialization
    void Start()
    {
        textComp = GetComponent<TextMeshPro>();
        message = textComp.text;
        Debug.Log(message);
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        yield return new WaitForSeconds(startTalk);
        foreach (char letter in message.ToCharArray())
        {
            
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }
}