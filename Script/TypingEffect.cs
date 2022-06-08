using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text msg;
    
    private string msg_text = "";

    [Range(0f,100f)]
    public float WaitForTypo;

    [Range(0.01f,0.99f)]
    public float typoSpeed;

    private void Awake()
    {
        msg_text = msg.text;
    }

    private void Start()
    {
        msg.text = "";
        StartCoroutine(typing());
    }

    IEnumerator typing()
    {
        yield return new WaitForSeconds(WaitForTypo);

        for(int i = 0; i<=msg_text.Length; i++)
        {
            msg.text = msg_text.Substring(0, i);

            yield return new WaitForSeconds(typoSpeed);
        }
    }
}
