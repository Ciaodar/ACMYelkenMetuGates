using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //load the next scene
            DoorEventHandler.doorEvent = () => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); };
        }
    }
}
