using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto_Button : MonoBehaviour
{
    public GameObject DoorTrigger;
    GameObject player;

    static public bool onButtonTrigger = false;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        DoorTrigger.SetActive(onButtonTrigger);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            onButtonTrigger = !onButtonTrigger;
        }
    }


}
