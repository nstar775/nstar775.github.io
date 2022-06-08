using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piano_Active : MonoBehaviour
{
    public GameObject Play_Piano_Box;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Play_Piano_Box.activeSelf == false)
                Play_Piano_Box.SetActive(true);
            else
                Play_Piano_Box.SetActive(true);
        }
    }
}
