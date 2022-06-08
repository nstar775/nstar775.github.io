using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject FadePanel;
    public float FadeTime;
    public bool PlayerHit;
    public GameObject Player_EndingCamera;
    public string[] Scenes;

    private void Start()
    {
        if(Player_EndingCamera.activeSelf)
            Player_EndingCamera.SetActive(false);

        if (FadePanel.activeSelf)
            FadePanel.SetActive(false);

        if (PlayerHit)
            PlayerHit = false;

        if (FadeTime > 0)
        {
            FadeTime = 0;
        }
    }

    private void Update()
    {
        if (PlayerHit == true)
        {
            FadeTime += 1 * Time.deltaTime;


            if (StageManager.Stage1_Hidden == true && StageManager.Stage2_Hidden == false)
            {
                if (FadeTime >= 5)
                {
                    SceneManager.LoadScene(Scenes[1]);
                    FadeTime = 0;
                    PlayerHit = false;
                }
            }
            else if (StageManager.Stage1_Hidden == false && StageManager.Stage2_Hidden == true)
            {
                if (FadeTime >= 5)
                {
                    SceneManager.LoadScene(Scenes[2]);
                    FadeTime = 0;
                    PlayerHit = false;
                }
            }
            else if (StageManager.Stage1_Hidden == true && StageManager.Stage2_Hidden == true)
            {
                if (this.gameObject.name == "Ending")
                {
                    if (FadeTime >= 5)
                    {
                        SceneManager.LoadScene(Scenes[2]);
                        FadeTime = 0;
                        PlayerHit = false;
                    }
                }
                else if (this.gameObject.name == "HiddenEnding")
                {
                    if (FadeTime >= 5)
                    {
                        SceneManager.LoadScene(Scenes[3]);
                        FadeTime = 0;
                        PlayerHit = false;
                    }
                }
            }
            else
            {
                if (FadeTime >= 5)
                {
                    SceneManager.LoadScene(Scenes[0]);
                    FadeTime = 0;
                    PlayerHit = false;
                }

            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            Player_EndingCamera.SetActive(true);
            FadePanel.SetActive(true);
            PlayerHit = true;
        }
    }
}
