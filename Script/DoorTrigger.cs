using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    [SerializeField]
    bool doorOpen = false;
    public AudioClip[] clip;
    public GameObject Open_Messege;
    public GameObject Close_Messege;

    public Animator animator;

    GameObject _player;


    //bool isOpened = false;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        door.GetComponent<Animator>().SetBool("DoorOpen", doorOpen);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == _player)
        {

            if (!doorOpen)
            {
                if (Open_Messege.activeSelf)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        doorOpen = true;
                        AudioManager.instance.SFXPlay("문 여는 소리", clip[0]);
                        Open_Messege.SetActive(false);
                    }
                }
                else if (!Open_Messege.activeSelf)
                {
                    Open_Messege.SetActive(true);
                    Close_Messege.SetActive(false);
                }
            }

            else if (doorOpen)
            {
                if (Close_Messege.activeSelf)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        doorOpen = false;
                        AudioManager.instance.SFXPlay("문 여는 소리", clip[1]);
                        Close_Messege.SetActive(false);
                    }
                }
                else if(!Close_Messege.activeSelf)
                {
                    Close_Messege.SetActive(true);
                    Open_Messege.SetActive(false);
                }
            }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            if (Open_Messege.activeSelf)
            {
                Open_Messege.SetActive(false);
            }

            if (Close_Messege.activeSelf)
            {
                Close_Messege.SetActive(false);
            }
        }
    }

    public void Initialized()
    {
        AudioManager.instance.SFXPlay("문 여는 소리 ", clip[0]);
        AudioManager.instance.SFXPlay("문 닫는 소리", clip[1]);
        door.SetActive(!doorOpen);
    }
}
