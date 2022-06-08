using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invoke_Game : MonoBehaviour
{
    public Animator Ending_UI_Anime;

    public GameObject EndingCanvas;
    
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Ending_UI_Anime.SetTrigger("Skip");

            if (EndingCanvas.activeSelf)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
