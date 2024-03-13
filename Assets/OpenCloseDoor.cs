using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
    public enum DoorState
    {
        Opening,
        Open,
        Closing,
        Close
    }

    public Vector3 deltaPosition = new Vector3(0f, -2f, 0f);
    public float speed = 5f;
    public float delay = 3f;

    private Vector3 _closedPosition;
    private Vector3 _openPosition;
    private float timer = 0f;
    

    public DoorState state;

    void Start()
    {
        state = DoorState.Close;

        _closedPosition = transform.position;
        _openPosition = transform.position + deltaPosition;
    }

    void Update()
    {

        switch(state)
        {
            case DoorState.Closing:
                OpenTheDoor(_closedPosition);

                if (Vector3.Distance(transform.position, _closedPosition) < 0.01f)
                {
                    timer = 0;
                    state = DoorState.Close;
                }
                break;
            case DoorState.Close:
                timer += Time.deltaTime;
                if (timer > delay)
                {
                    state = DoorState.Opening;
                }
                break;
            case DoorState.Opening:
                OpenTheDoor(_openPosition);

                if (Vector3.Distance(transform.position, _openPosition) < 0.01f)
                {
                    timer = 0;
                    state = DoorState.Open;
                }
                break;
            case DoorState.Open:
                timer += Time.deltaTime;
                
                if(timer > delay)
                {
                    state = DoorState.Closing;
                }
                break;
        }
    }

    public void OpenTheDoor(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

}
