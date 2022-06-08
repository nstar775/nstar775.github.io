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
        //UI�� ���������� Ÿ�̸Ӹ� ī��Ʈ��
        if(Tutorial_UI.activeSelf)
            Timer += 1 * Time.deltaTime;

        // UI�� 30�� ���� ���������� 30�� �Ŀ� ���� ��Ŵ. 
        if(Timer >= 30)
        {
            Timer = 0.1f;

            if (Tutorial_UI.activeSelf)
            {
                Tutorial_UI.SetActive(false);
                Game_Manager.pauseGame();
            }
        }

        //UI�� �������� ��, Esc�� ������ ������, Timer�� 0���� �ʱ�ȭ ��Ŵ.
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


    //������ ���� ������ �߻�. (�÷��̾� ī���ͷ� �ѹ��� �����ϰ� ��.)
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
