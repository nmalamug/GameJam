using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Entity
{
    bool isActive= true; 
    public void Activate(){

        isActive=!isActive;
        Debug.Log("switch has been flipped");
    }



    // Start is called before the first frame update
    void Start()
    {
        //getLogic();
        //gridPosition = new Vector3Int((int)transform.position.x, (int)transform.position.y,0);
        //setPosition();
    }


    public override void updateEntity(){
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
