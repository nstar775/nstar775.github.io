using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_UI_Move : MonoBehaviour
{
    public GameObject[] Story_UIs;
    public GameObject UI_Parent;

    private int n = 0;

    private void Awake()
    {
        Story_UIs[0].SetActive(true);    
    }

    private void Update()
    {
        if (UI_Parent.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (n < Story_UIs.Length-1)
                {
                    n++;
                    Story_UIs[n - 1].SetActive(false);
                    Story_UIs[n].SetActive(true);
                }
                else if(n >= Story_UIs.Length-1)
                {
                    n = 0;
                    Story_UIs[n].SetActive(true);
                    Story_UIs[Story_UIs.Length-1].SetActive(false);
                }
            }
        }
    }

    public void Initialized()
    {
        n = 0;
    }

}
