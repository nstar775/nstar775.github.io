using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDoor : MonoBehaviour
{
    [SerializeField]
    GameObject stageDoor;

    GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            stageDoor.SetActive(true);
            Destroy(gameObject);
        }
    }
}
