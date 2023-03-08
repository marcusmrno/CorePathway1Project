using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSetter : MonoBehaviour
{
    void OnTriggerStay(Collider col){
        if(col.gameObject.tag == "Player"){
            col.gameObject.GetComponent<PlayerMovement>().setSpawnPoint(gameObject);
        }
    }
}
