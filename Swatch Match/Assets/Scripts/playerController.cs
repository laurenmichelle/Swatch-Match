using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    string playerInput;
    public int column;
    public int row;
    //Vector2 playerPrevPosition;
    //Vector2 playerNextPosition;
    // Start is called before the first frame update
    void Start()
    {
        //playerPrevPosition = new Vector2()
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerInput = "up";
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerInput = "down";
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerInput = "right";
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerInput = "left";
        }
    }


   private void Swap(string direction) 
    {
        if(direction == "up" & )
        {

        }
    }
}
