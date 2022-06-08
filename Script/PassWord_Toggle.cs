using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWord_Toggle : MonoBehaviour
{
    private GameObject player;
    public GameObject Respawn;

    private bool pauseTime = false;
    
    public GameObject PasswordBox;
    public GameObject ask_UI;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (PasswordBox)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Game_Manager.instance.Cursor_LockOn = true;
                PasswordBox.SetActive(false);
                Game_Manager.pauseGame();
            }
        }

        if (PassWord_Box.Pass)
        {
            ask_UI.SetActive(false);
            player.transform.position = Respawn.transform.position;
            this.gameObject.SetActive(false);
            PassWord_Box.Pass = false;
            Game_Manager.pauseGame();
        }
    }

    //플레이어가 오브젝트의 접근 했는지 체크
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            ask_UI.SetActive(true);
            OnPW_Box();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            ask_UI.SetActive(false);
        }
    }


    //패스워드 박스 온 오프
    void OnPW_Box() 
    {
        if (ask_UI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PasswordBox.SetActive(true);
                Game_Manager.instance.Cursor_LockOn = false;
                Game_Manager.pauseGame();
            }
        }
    }

}
