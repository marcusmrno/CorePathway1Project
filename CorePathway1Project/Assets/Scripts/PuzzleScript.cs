using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour
{
    public bool isSolved;
    public bool lethal;//if it will kill the player on failure
    public GameObject firstTrigger;
    public GameObject secondTrigger;
    public GameObject thridTrigger;

    void Update(){
        isSolved = puzzleInputs();
        checkFail();
        lockout();
    }
    public bool getSolved(){
        return isSolved;
    }

    private bool getInputs(GameObject trigger){
        if(trigger.tag == "Button"){
            return trigger.GetComponent<ButtonScript>().returnState();
        }
        if(trigger.tag == "Plate"){
            return trigger.GetComponent<PlateScript>().getOnPlate();
        }
        return false;
    }
    bool inputOne;
    bool inputTwo;
    bool inputThree;
    private bool puzzleInputs(){
        inputOne = getInputs(firstTrigger);
        inputTwo = getInputs(secondTrigger);
        inputThree = getInputs(thridTrigger);

        if(inputOne && inputTwo && inputThree){
            if(failed){
                if(!locked && lethal){
                    GameObject.Find("Player").GetComponent<PlayerMovement>().die();
                }
                locked = true;
                return false;
            }
            else if(!locked){
                return true;
            }
            
        }
        return false;

    }

    bool failed;
    private void checkFail(){
        if(inputThree && (!inputTwo || !inputOne)){//if 3 is inputed before two or 1
            failed = true;
        }
        if(inputTwo && !inputOne){//if 2 is inputed before 1
            failed = true;
        } 
    }

    bool locked;
    private void lockout(){//will disable lockout once all three inputs are cleared
        if(!inputOne && !inputTwo && !inputThree){
            locked = false;
            failed = false;
        }
    }
}
