using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }
}
