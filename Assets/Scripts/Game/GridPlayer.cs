

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridPlayer : MonoBehaviour
{
    public GameLogic gameLogic;
    public List<Action> actions = new List<Action>();
    public Vector3Int gridPosition;
    public Vector3Int startingPosition = new Vector3Int(0,0,0);
    public EchoManager echoManager;
    private bool timeToUpdate;
    

    // Start is called before the first frame update
    void Start()
    {
        gridPosition = startingPosition;
    }


    // Update is called once per frame
    void Update()
    {
        //Update the grid position of the object based on button press
        //Then update the surroundings (Managed in GameLogic.cs)
            if(Time.timeScale != 0){
                if(Input.GetKeyDown(KeyCode.W) && gameLogic.isValidMove("up")){
                    gridPosition.y++;
                    timeToUpdate = true;
                    actions.Add(new Action(Action.ActionType.Move, gridPosition, "up"));
                }else if(Input.GetKeyDown(KeyCode.A) && gameLogic.isValidMove("left")){
                    gridPosition.x--;
                    timeToUpdate = true;
                    actions.Add(new Action(Action.ActionType.Move, gridPosition, "left"));
                }else if(Input.GetKeyDown(KeyCode.S) && gameLogic.isValidMove("down")){
                    gridPosition.y--;
                    timeToUpdate = true;
                    actions.Add(new Action(Action.ActionType.Move, gridPosition, "down"));
                }else if(Input.GetKeyDown(KeyCode.D) && gameLogic.isValidMove("right")){
                    gridPosition.x++ ;
                    timeToUpdate = true;
                    actions.Add(new Action(Action.ActionType.Move, gridPosition, "right"));
                }else if(Input.GetKeyDown(KeyCode.X) && gameLogic.isAdjacentInteractable(gridPosition)){
                    /*
                        Put code here to call function to interact with object
                    */
                    Debug.Log("Interact Action Triggered");
                    actions.Add(new Action(Action.ActionType.Interact, gridPosition));
                }else if(Input.GetKeyDown(KeyCode.Q) && echoManager.canCreateEcho()){
                    echoReset();
                }
            }
            if(timeToUpdate){
                timeToUpdate = false;
                updateSurroundings();
            }
    }


    void FixedUpdate(){
        //Update the position of the object on screen.
        transform.position = gameLogic.getScreenPosition(gridPosition);
    }

    public void updateSurroundings(){
        gameLogic.updateSurroundings();
        echoManager.updateEchos();
        if(actions.Count > 0 && actions[actions.Count - 1].actionType == Action.ActionType.Interact){
    foreach(GameObject entity in gameLogic.entityManager.gameEntities){
        if (entity.transform.position == gameLogic.getScreenPosition(gridPosition)){
            Switch switchAtPosition = entity.GetComponent<Switch>();
            if (switchAtPosition != null){
                Debug.Log("Switch is Here!");
                switchAtPosition.Activate();
                break;
            }
        }
    }
}
    }

    public void echoReset(){
        echoManager.createEcho(startingPosition, actions);
        echoManager.resetEchos();
        actions = new List<Action>();
        gridPosition = startingPosition;
    }

}



