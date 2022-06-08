using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart()
    {
        Debug.Log("������ �����մϴ�.");
        SceneManager.LoadScene("Loading", LoadSceneMode.Single);
    }

    public void OnClickEnding()
    {
        Debug.Log("���� �ַ����� ���ϴ�.");
        SceneManager.LoadScene("Ending_Gallery", LoadSceneMode.Single);
    }

    public void OnClickExit()
    {
        Debug.Log("������ �����մϴ�.");
        Application.Quit();
    }
}