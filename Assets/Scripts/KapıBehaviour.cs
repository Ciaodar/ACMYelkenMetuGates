using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
   
    [SerializeField] String TextToSend;
    [Space] [SerializeField] private bool wrongAnswer=false;
    
    
    [Header("Texts")]
    [SerializeField] private TextMeshPro AboveDoorText;
    [SerializeField] private TextMeshPro other1;
    [SerializeField] private TextMeshPro other2;
    
    
    public enum DoorBehaviour { FallDown, FlyAway, StayPut }
    public DoorBehaviour doorBehaviour;
    private MeshCollider col;
    
    public float fallSpeed = 3.0f;
    public float flySpeed = 2.0f;
    public float flyAwayForce = 3.0f;
    public float flyAwayTorque = 3.0f;

    public List<KapıBehaviour> doors;
    //public List<TextMeshPro> texts;
    
    private Rigidbody rb;
    
    void Start()
    {
        doors = transform.parent.parent.GetComponentsInChildren<KapıBehaviour>().ToList();
        //texts = transform.parent.parent.GetComponentsInChildren<TextMeshPro>().ToList();
        col = GetComponent<MeshCollider>();
        rb = GetComponent<Rigidbody>();
        RandomizeDoorBehaviour();
    }
    
    void RandomizeDoorBehaviour()
    {
        Array values = Enum.GetValues(typeof(DoorBehaviour));
        doorBehaviour = (DoorBehaviour)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }
    
    
    public void Behave()
    {
        other1.text = AboveDoorText.text;
        other2.text = AboveDoorText.text;
        
        //send the texts to the LevelHandler
        LevelHandler.SaveTheAnswer(AboveDoorText.text);
        LevelHandler.SaveTheFact(TextToSend);
        
        
        GoAway();
    }

    IEnumerator FallDown()
    {
        while (transform.position.y > -10f)
        {
            transform.Translate(Vector3.back * (fallSpeed * Time.deltaTime));
            yield return null;
        }
        Destroy(gameObject);
    }
    
    IEnumerator FlyAway()
    {
        Destroy(col);
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * flyAwayForce, ForceMode.Impulse);
        rb.AddForce(Vector3.left * flyAwayForce, ForceMode.Impulse);
        rb.AddTorque(Vector3.up * flyAwayTorque, ForceMode.Impulse);
        
        Destroy(this);
        yield return new WaitForSeconds(flySpeed);
        Destroy(gameObject);
    }
    
    IEnumerator StayPut()
    {
        col.enabled = true;
        col.convex = true;
        rb.isKinematic = false;
        Destroy(this);
        yield return new WaitForSeconds(0.1f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !wrongAnswer)
        {
            Behave();
            //finds all KapıBehaviours only in children
            
            foreach (KapıBehaviour door in doors)
            {
                if (door!=null)
                {
                    door.transform.GetComponent<MeshCollider>().enabled = false;
                    if(this != door)
                        door.GoAway();
                }
            }
        }
    }
    
    public void GoAway()
    {
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
}
