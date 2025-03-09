using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MilkBehaver : MonoBehaviour
{
    //gets KapıBehaviour component from children
    //and calls the GoAway function
    private Array _doors;
    private void Start()
    {
         _doors = GetComponentsInChildren<KapıBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //calls the GoAway function
            foreach (KapıBehaviour door in _doors)
            {
                door.GoAway();
            }
        }
    }
}
