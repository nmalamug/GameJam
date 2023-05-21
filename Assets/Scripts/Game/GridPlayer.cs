

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
    public LayerMask collide;
    public float speed = 15;
    public int id = 0;

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
                if(Input.GetKeyDown(KeyCode.W) && isValidMove("up")){
                    gridPosition.y++;
                    timeToUpdate = true;
                    actions.Add(new Action(Action.ActionType.Move, gridPosition, "up"));
                }else if(Input.GetKeyDown(KeyCode.A) && isValidMove("left")){
                    gridPosition.x--;
                    timeToUpdate = true;
                    actions.Add(new Action(Action.ActionType.Move, gridPosition, "left"));
                }else if(Input.GetKeyDown(KeyCode.S) && isValidMove("down")){
                    gridPosition.y--;
                    timeToUpdate = true;
                    actions.Add(new Action(Action.ActionType.Move, gridPosition, "down"));
                }else if(Input.GetKeyDown(KeyCode.D) && isValidMove("right")){
                    gridPosition.x++ ;
                    timeToUpdate = true;
                    actions.Add(new Action(Action.ActionType.Move, gridPosition, "right"));
                }else if(Input.GetKeyDown(KeyCode.X)){
                    timeToUpdate = true;
                    actions.Add(new Action(Action.ActionType.Interact, gridPosition));
                    gameLogic.processInteraction(id);
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
        transform.position = Vector3.MoveTowards(transform.position,gameLogic.getScreenPosition(gridPosition), speed*Time.deltaTime);
    }

    public void updateSurroundings(){
        gameLogic.updateSurroundings();
        echoManager.updateEchos();
    }

    public void echoReset(){
        echoManager.createEcho(startingPosition, actions);
        echoManager.resetEchos();
        actions = new List<Action>();
        gridPosition = startingPosition;
        transform.position = gameLogic.getScreenPosition(startingPosition);
    }

    bool isValidMove(string direction){
        switch (direction){
            case "up":
                if(Physics2D.OverlapCircle(gameLogic.getScreenPosition(gridPosition + Vector3Int.up), .4f, collide)){
                    return false;
                }
             break;
            case "down":
                if(Physics2D.OverlapCircle(gameLogic.getScreenPosition(gridPosition + Vector3Int.down), .4f, collide)){
                    return false;
                }
             break;
            case "left":
                if(Physics2D.OverlapCircle(gameLogic.getScreenPosition(gridPosition + Vector3Int.left), .4f, collide)){
                    return false;
                }
             break;
            case "right":
                if(Physics2D.OverlapCircle(gameLogic.getScreenPosition(gridPosition + Vector3Int.right), .4f, collide)){
                    return false;
                }
             break;
        }
        return true;
    }
}



