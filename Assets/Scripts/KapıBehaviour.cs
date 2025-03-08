using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//doors have 3 different behaviours slowly falling down, flying away, and staying put
//to fall down, the door has to be a child of a parent object with a rigidbody
//to fly away, the door has to have a rigidbody, then used force on door to make it jump and fly away
//to stay put, the door just closes the collider and lets the player pass through

//takes 3 different TextMeshPro objects serialized
//makes their text equal to the one above this door

public class KapıBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshPro AboveDoorText;
    [SerializeField] private TextMeshPro other1;
    [SerializeField] private TextMeshPro other2;
    
    public enum DoorBehaviour { FallDown, FlyAway, StayPut }
    public DoorBehaviour doorBehaviour;
    public float fallSpeed = 1.0f;
    public float flySpeed = 1.0f;
    public float flyHeight = 1.0f;
    public float flyAwayForce = 1.0f;
    public float flyAwayTorque = 1.0f;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RandomizeDoorBehaviour();
    }
    
    void RandomizeDoorBehaviour()
    {
        Array values = Enum.GetValues(typeof(DoorBehaviour));
        doorBehaviour = (DoorBehaviour)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }
    
    
    void Behave()
    {
        other1.text = AboveDoorText.text;
        other2.text = AboveDoorText.text;
        
        //disable the collider of other doors
        Array arr = FindObjectsOfType<KapıBehaviour>();
        foreach (KapıBehaviour door in arr)
        {
            if (door != this)
            {
                door.transform.GetComponent<MeshCollider>().enabled = false;
            }
        }
        
        switch (doorBehaviour)
        {
            case DoorBehaviour.FallDown:
                StartCoroutine(FallDown());
                break;
            case DoorBehaviour.FlyAway:
                StartCoroutine(FlyAway());
                break;
            case DoorBehaviour.StayPut:
                StartCoroutine(StayPut());
                break;
        }
    }

    IEnumerator FallDown()
    {
        while (transform.position.y > -50f)
        {
            transform.Translate(Vector3.down * (fallSpeed * Time.deltaTime));
            yield return null;
        }
    }
    
    IEnumerator FlyAway()
    {
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * flyAwayForce, ForceMode.Impulse);
        rb.AddTorque(Vector3.up * flyAwayTorque, ForceMode.Impulse);
        yield return new WaitForSeconds(flySpeed);
        Destroy(gameObject);
    }
    
    IEnumerator StayPut()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshCollider>().enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Behave();
        }
    }
}
