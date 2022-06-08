using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart()
    {
        Debug.Log("게임을 시작합니다.");
        SceneManager.LoadScene("Loading", LoadSceneMode.Single);
    }

    public void OnClickEnding()
    {
        Debug.Log("엔딩 겔러리를 엽니다.");
        SceneManager.LoadScene("Ending_Gallery", LoadSceneMode.Single);
    }

    public void OnClickExit()
    {
        Debug.Log("게임을 종료합니다.");
        Application.Quit();
    }
}