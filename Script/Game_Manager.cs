using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    [SerializeField]
    public bool Cursor_LockOn;
    public static bool pauseTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        Cursor_LockOn = true;
    }

    private void Update()
    {
        CursorLockOn();

        if (Input.GetKeyDown(KeyCode.LeftControl)&& Input.GetKeyDown(KeyCode.Escape))
            Cursor_LockOn = false;
        if (Input.GetKeyUp(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor_LockOn == false)
            {
                Cursor_LockOn = true;
            }
            else{ } //None
        }
    }


    private void CursorLockOn()
    {
        if (Cursor_LockOn == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    public static void pauseGame()
    {
        if (!pauseTime)
        {
            Time.timeScale = 0;
            pauseTime = true;
        }
        else if (pauseTime)
        {
            Time.timeScale = 1;
            pauseTime = false;
        }
    }

}
