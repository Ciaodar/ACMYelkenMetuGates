using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCloser : MonoBehaviour
{
    public float speed = 1.0f;
    public bool passed = false;
    private void OnTriggerEnter(Collider other)
    {//Slowly close the gate
        if (other.gameObject.CompareTag("Player"))
        {
            passed = true;
        }
    }
    
    private void Update()
    {
        if (passed)
        {
            var position = transform.position;
            position = Vector3.MoveTowards(position, new Vector3(position.x, -0.9f, position.z), speed * Time.deltaTime);
            transform.position = position;
        }
    }
}
