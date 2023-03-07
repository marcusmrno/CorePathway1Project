using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlateScript : PlateScript
{
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(getOnPlate()){
            target.GetComponent<PlayerMovement>().die();
        }
    }
}
