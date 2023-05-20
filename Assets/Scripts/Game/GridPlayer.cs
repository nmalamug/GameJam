using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayer : MonoBehaviour
{
    public GameLogic gameLogic;

    public Vector3Int gridPosition = new Vector3Int(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update the grid position of the object based on button press
        //Then update the surroundings (Managed in GameLogic.cs)
        if(Time.timeScale != 0){
            if(Input.GetKeyDown(KeyCode.W) && gameLogic.isValidMove("up")){
                gridPosition.y++;
                gameLogic.updateSurroundings();
            }else if(Input.GetKeyDown(KeyCode.A) && gameLogic.isValidMove("left")){
                gridPosition.x--;
                gameLogic.updateSurroundings();            
            }else if(Input.GetKeyDown(KeyCode.S) && gameLogic.isValidMove("down")){
                gridPosition.y--;
                gameLogic.updateSurroundings();
            }else if(Input.GetKeyDown(KeyCode.D) && gameLogic.isValidMove("right")){
                gridPosition.x++ ;
                gameLogic.updateSurroundings();
            }else if(Input.GetKeyDown(KeyCode.X) && gameLogic.isAdjacentInteractable()){
                /*
                    Put code here to call function to interact with object
                */
                gameLogic.updateSurroundings();
            }
        }
    }

    void FixedUpdate(){
        //Update the position of the object on screen. 
        transform.position = gameLogic.getScreenPosition(gridPosition);
    }
}
