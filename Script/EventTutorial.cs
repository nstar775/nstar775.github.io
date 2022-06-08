using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTutorial : MonoBehaviour
{
    public GameObject Tutorial_UI;


    private int PlayerCount = 0;
    private float Timer = 0f;

    private void FixedUpdate()
    {
        //UI가 켜져있으면 타이머를 카운트함
        if(Tutorial_UI.activeSelf)
            Timer += 1 * Time.deltaTime;

        // UI가 30초 동안 켜져있으면 30초 후에 종료 시킴. 
        if(Timer >= 30)
        {
            Timer = 0.1f;

            if (Tutorial_UI.activeSelf)
            {
                Tutorial_UI.SetActive(false);
                Game_Manager.pauseGame();
            }
        }

        //UI가 열려있을 때, Esc를 누르면 닫히고, Timer를 0으로 초기화 시킴.
        if (Tutorial_UI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Tutorial_UI.SetActive(false);
                Timer = 0.1f;
                Game_Manager.pauseGame();
            }
        }


    }


    //유저가 존에 들어오면 발생. (플레이어 카운터로 한번만 말생하게 함.)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerCount < 1)
            {
                PlayerCount++;
                if (!Tutorial_UI.activeSelf)
                {
                    Tutorial_UI.SetActive(true);
                    Game_Manager.pauseGame();
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Tutorial_UI.SetActive(true);
                Game_Manager.pauseGame();
            }
        }
    }

    public void Initialized()
    {
        Timer = 0;
        PlayerCount = 0;
    }

}
