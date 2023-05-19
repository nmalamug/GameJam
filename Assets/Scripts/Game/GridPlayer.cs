using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayer : MonoBehaviour
{
    public GameLogic gameLogic;
    public List<Action> actions = new List<Action>();
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
        if(Input.GetKeyDown(KeyCode.W) && gameLogic.isValidMove("up")){
            gridPosition.y += (int)Time.timeScale;
            actions.Add(new Action(Action.ActionType.Move, gridPosition, "up"));
            gameLogic.updateSurroundings();
        }else if(Input.GetKeyDown(KeyCode.A) && gameLogic.isValidMove("left")){
            gridPosition.x -= (int)Time.timeScale;
            actions.Add(new Action(Action.ActionType.Move, gridPosition, "left"));
            gameLogic.updateSurroundings();            
        }else if(Input.GetKeyDown(KeyCode.S) && gameLogic.isValidMove("down")){
            gridPosition.y -= (int)Time.timeScale;
            actions.Add(new Action(Action.ActionType.Move, gridPosition, "down"));
            gameLogic.updateSurroundings();
        }else if(Input.GetKeyDown(KeyCode.D) && gameLogic.isValidMove("right")){
            gridPosition.x += (int)Time.timeScale;
            actions.Add(new Action(Action.ActionType.Move, gridPosition, "right"));
            gameLogic.updateSurroundings();
        }else if(Input.GetKeyDown(KeyCode.X) && gameLogic.isAdjacentInteractable()){
            actions.Add(new Action(Action.ActionType.Interact, gridPosition));

            /*
                Put code here to call function to interact with object
            */
            gameLogic.updateSurroundings();
        }
    }

    void FixedUpdate(){
        //Update the position of the object on screen. 
        transform.position = gameLogic.getScreenPosition(gridPosition);
    }
}
