using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Piano : MonoBehaviour
{
    [SerializeField]
    GameObject PianoPanel;

    [SerializeField]
    GameObject piano_object;

    GameObject player;

    [SerializeField]
    GameObject askUI;

    public GameObject DoorTrigger;

    public AudioClip[] clip;

    bool isPlayPiano = false;

    public int openCount = 0;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (openCount >= 6)
        {
            isPlayPiano = false;
            piano_object.SetActive(false);
            DoorTrigger.SetActive(true);
            AudioManager.instance.SFXPlay("�ǾƳ밡 �������!", clip[8]);
            Game_Manager.pauseGame();
        }
        Piano();
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            askUI.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {
                if (!PianoPanel.activeInHierarchy)
                {
                    PianoPanel.SetActive(true);
                    Game_Manager.pauseGame();
                    isPlayPiano = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            askUI.SetActive(false);
        }
    }

    private void Piano()
    {
        if (isPlayPiano == true)
        {
            askUI.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPlayPiano = false;
                askUI.SetActive(false);
                Game_Manager.pauseGame();
            }
            if (Input.GetKeyDown(KeyCode.A)) //C (��)
            {
                if (openCount >= 0)
                {
                    openCount = 0;
                }

                AudioManager.instance.SFXPlay("��", clip[0]);
            }

            if (Input.GetKeyDown(KeyCode.S)) //D (��)
            {
                if (openCount >= 0)
                {
                    openCount = 0;
                }

                AudioManager.instance.SFXPlay("��", clip[1]);
            }

            if (Input.GetKeyDown(KeyCode.D)) // E (��)
            {
                if (openCount == 1)
                    openCount += 1;
                else
                    openCount = 0;

                AudioManager.instance.SFXPlay("��", clip[2]);
            }

            if (Input.GetKeyDown(KeyCode.F)) // F (��)
            {
                if (openCount == 2)
                    openCount += 1;
                else if (openCount == 5)
                    openCount += 1;
                else
                    openCount = 0;

                AudioManager.instance.SFXPlay("��", clip[3]);
            }

            if (Input.GetKeyDown(KeyCode.J)) //G (��)
            {
                if (openCount == 0)
                    openCount += 1;
                else if (openCount == 3)
                    openCount += 1;
                else
                    openCount = 0;

                AudioManager.instance.SFXPlay("��", clip[4]);
            }

            if (Input.GetKeyDown(KeyCode.K)) //A (��)
            {
                if (openCount == 4)
                {
                    openCount += 1;
                }
                else
                    openCount = 0;

                AudioManager.instance.SFXPlay("��", clip[5]);
            }

            if (Input.GetKeyDown(KeyCode.L)) //B (��)
            {
                if (openCount >= 0)
                {
                    openCount = 0;
                }

                AudioManager.instance.SFXPlay("��", clip[6]);
            }

            if (Input.GetKeyDown(KeyCode.Semicolon) || Input.GetKeyDown(KeyCode.Colon)) // C (���� ��)
            {
                if (openCount >= 0)
                {
                    openCount = 0;
                }

                AudioManager.instance.SFXPlay("����_��", clip[7]);
            }
        }
        if (isPlayPiano == false)
        {
            PianoPanel.SetActive(false);
            player.SetActive(true);
        }
    }

    public void Initialized()
    {
        openCount = 0;
    }
}
