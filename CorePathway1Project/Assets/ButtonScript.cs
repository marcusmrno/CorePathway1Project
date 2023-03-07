using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool toggle;
    private bool isPressed = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    public bool returnState()//returns if pressed or not
    {
        return isPressed;
    }

    private void Update()
    {
        if(!toggle && isPressed)
        {
            isPressed = false;
        }
    }

    public void pressButton()//switch the button press
    {
        isPressed = !isPressed;
        player.GetComponent<PlayerMovement>().die();
    }
}
