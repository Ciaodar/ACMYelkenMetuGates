using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this scipt is used to load the first level
public class PlayStart : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        //load the next scene
        DoorEventHandler.doorEvent = () => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); };
    }
}
