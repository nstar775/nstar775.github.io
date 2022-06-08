using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Object : MonoBehaviour
{
    public GameObject Object_Button;
    public GameObject Push_UI;
    public StageManager stageManager;
    GameObject player;

    public AudioClip[] clip;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject == player)
        {
            if (Push_UI.activeInHierarchy == false)
            {
                Push_UI.SetActive(true); 
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                AudioManager.instance.SFXPlay("버튼 소리", clip[0]);
                Stage01_ButtonTag_Event();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Push_UI.SetActive(false);
    }

    void Stage01_ButtonTag_Event()
    {
        if (this.gameObject.tag == "WinterBook")
        {
            stageManager.WinterCounter ++;
        }
        else if(Object_Button.tag == "SummerBook")
        {
            stageManager.SummerCounter++;
        }
        else if(Object_Button.tag == "AutumnBook")
        {
            stageManager.FallCounter++;
        }
        else if(Object_Button.tag == "SpringBook")
        {
            stageManager.SpringCounter++;
        }
        else
        {
            print(this.gameObject.tag);
        }
    }
}
