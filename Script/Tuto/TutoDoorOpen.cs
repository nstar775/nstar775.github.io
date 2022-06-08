using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoDoorOpen : MonoBehaviour
{
    [SerializeField]
    GameObject door1;
    GameObject door2;

    GameObject _player;

    //bool isOpened = false;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == _player)
        {
            door1.SetActive(false);
            door2.SetActive(false);
        }
    }

    public void Initialized()
    {
        door1.SetActive(true);
        door2.SetActive(true);
    }
}
