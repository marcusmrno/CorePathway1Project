using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public GameObject target;//gameobject it will look for;
    public bool onPlate;
    void OnTriggerStay(Collider col){
        if(col.gameObject == target){
            onPlate = true;
        }
    }

    public void OnTriggerExit(){
        onPlate = false;
    }

    public bool getOnPlate(){
        return onPlate;
    }
}
