using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public GameObject hand;

    GameObject itemPickup;
    bool canPickup = false;
    [HideInInspector]public bool hasItem = false;

    void Update()
    {
        if (canPickup)
        {
            if (Input.GetKeyDown("e"))
            {
                if (!hasItem)
                {
                    pickUpItem(itemPickup);
                }
                else
                {
                    dropItem(itemPickup);
                }
            }

        }
    }

    void OnTriggerStay(Collider item)
    {
        if (!hasItem)
        {
            if(item.gameObject.tag == "Item")
            {
                canPickup = true;
                itemPickup = item.gameObject;
            }
            else if(item.gameObject.tag == "button")
            {

            }
                
        }
    }

    void OnTriggerExit(Collider item)
    {
        if (!hasItem) { canPickup = false; }
    }

    public void dropItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        hasItem = false;
    }

    public void pickUpItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = hand.transform.position;
        item.transform.parent = hand.transform;
        hasItem = true;
    }
}
