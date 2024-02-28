using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Vector3 deltaPosition = new Vector3(0f, -2f, 0f);
    public float speed = 5f;
    public float waitTime = 15f;

    private Vector3 _closedPosition;
    private Vector3 _openPosition;

    // Start is called before the first frame update
    void Start()
    {
        _closedPosition = transform.position;
        _openPosition = transform.position + deltaPosition;    
    }

    public void OpenTheDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, _openPosition, speed * Time.deltaTime);
    }

    /*
    void Update()
    {
        if (Time.time > waitTime) 
        {
            OpenTheDoor();
        }
    }
    */
}
