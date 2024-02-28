using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public OpenDoor door;

    public int collectedItems = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(collectedItems >= 7)
        {
            door.OpenTheDoor();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Name of GO:" + collision.gameObject.name);

        if(collision.gameObject.tag == "Collectable")
        {
            collectedItems++;
            Destroy(collision.gameObject);
        }

    }

}
