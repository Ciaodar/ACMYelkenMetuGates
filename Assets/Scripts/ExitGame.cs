using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        DoorEventHandler.doorEvent = () => { Application.Quit(); };
    }
}
