using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this scipt is used to load the first level
public class PlayStart : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        DoorEventHandler.doorEvent = () => { UnityEngine.SceneManagement.SceneManager.LoadScene(1); };
    }
}
