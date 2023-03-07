using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public GameObject hand;

    GameObject objectIntract;
    bool canPickup = false;
    bool canInteract = false;
    [HideInInspector]public bool hasItem = false;

    void Update()
    {
        manageInteractions();
    }

    void OnTriggerStay(Collider item)
    {
        if (!hasItem)
        {
            objectIntract = item.gameObject;
            if (item.gameObject.tag == "Item")
            {
                canPickup = true;
            }
            else if(item.gameObject.tag == "Button")
            {
                canInteract = true;
            }
         
        }
    }

    void OnTriggerExit(Collider item)
    {
        if (!hasItem) { canPickup = false; }
        canInteract = false;
    }

    public void manageInteractions()
    {
        if (Input.GetKeyDown("e"))
        {
            if (canPickup)
            {
                if (!hasItem)
                {
                    pickUpItem(objectIntract);
                }
                else
                {
                    dropItem(objectIntract);
                }
            }
            else if (canInteract && !hasItem)
            {
                objectIntract.GetComponent<ButtonScript>().pressButton();
            }
        }
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
