using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintEvent : MonoBehaviour
{
    public GameObject Can_You_Read_UI;
    public GameObject Hint;

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hint.SetActive(false);
            Can_You_Read_UI.SetActive(false);
            pauseGame();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject == player)
        {
            if (!Can_You_Read_UI.activeSelf)
            {
                Can_You_Read_UI.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Can_You_Read_UI.SetActive(false);
                
                if (!Hint.activeSelf)
                {
                    Hint.SetActive(true);
                    pauseGame();
                }
            }

        }
    }


    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject == player)
        Can_You_Read_UI.SetActive(false);
    }

    private void pauseGame()
    {
        if (Hint.activeSelf)
        {
            Time.timeScale = 0;
        }
        else if (!Hint.activeSelf)
        {
            Time.timeScale = 1;
        }
    }
}
