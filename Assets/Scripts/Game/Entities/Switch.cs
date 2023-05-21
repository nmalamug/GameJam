using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Entity
{
    //For every new entity just copy this script
    //Every entity has a gridPosition
    //For example, to move - Do grid position++ and in the Fixed Update, 
    //Do transform.position = Vector3.movtowards(..,...,...);
    bool isActive= false; 
    public void Activate(){
        isActive=!isActive;
        Debug.Log("switch has been flipped");
    }

    public void echoUpdate(){
        gridPosition.x++;
    }

    public void levelReset(){
        gridPosition = startingPosition;
        snapToGrid();
        isActive = false;
    }

    public void playerMove(){
        gridPosition.y--;
    }

    // Start is called before the first frame update
    void Start()
    {
        init(); //Init gets logic and snaps to grid. 
    }


}
