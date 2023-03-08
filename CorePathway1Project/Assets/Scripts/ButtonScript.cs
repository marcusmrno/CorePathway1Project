using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool toggle;
    public bool spinner;//does it spin when activiated
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

    float timer = 0f;
    private void Update()
    {
        if(!toggle && isPressed)
        {
            timer += Time.deltaTime;
            if((int)timer == 1){
                isPressed = false;
                timer = 0;
            }
        }
        if(spinner && isPressed)
        {
            transform.Rotate(0.25f,0.25f,0.25f);
        }
    }

    public void pressButton()//switch the button press
    {
        isPressed = !isPressed;
    }
}
