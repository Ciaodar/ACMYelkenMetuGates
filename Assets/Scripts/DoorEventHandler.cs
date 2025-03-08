using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

//this script takes a function from doors and calls it when the player enters the trigger
//the func
public class DoorEventHandler : MonoBehaviour
{
    public static Action doorEvent;
    public GameObject player;
    private Vector3 SpawnPoint;
    

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        SpawnPoint = player.transform.position;
        doorEvent = (() => { 
            //restart the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        doorEvent?.Invoke();
    }
}
