using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoManager : MonoBehaviour
{
    public List<GameObject> echoes;
    public List<Echo> usableEchos;
    public List<List<Action>> storedActions;
    public List<Queue<Action>> actionsToDo;
    public GameObject anEcho;
    public GameLogic gameLogic;
    public int numEchoes;
    public int maxEchoes; // Maximum number of iterations for testing
    // Start is called before the first frame update
    public Vector3Int echoStartingPos;
    void Start()
    {
        echoes = new List<GameObject>();
        storedActions = new List<List<Action>>();
        actionsToDo = new List<Queue<Action>>();
        numEchoes = 0;
        maxEchoes = 2;
    }

    public bool canCreateEcho(){
        if(numEchoes<maxEchoes){
            return true;
        }else{
            return false;
        }
    }

    public void createEcho(Vector3Int startingPosition, List<Action> actions){
        echoStartingPos = startingPosition;
        echoes.Add(Instantiate(anEcho, gameLogic.getScreenPosition(startingPosition), transform.rotation));
        storedActions.Add(actions);
        numEchoes++;
    }
    
    public void updateEchos(){
        int echonum = 0;
        foreach(var i in actionsToDo){
            if (i != null && i.Count > 0)
            {
                Action action = i.Dequeue();
                if (action.actionType == Action.ActionType.Move)
                {
                    usableEchos[echonum].target = gameLogic.getScreenPosition(action.position);
                    if(action.direction == "right"){
                        usableEchos[echonum].transform.rotation = new Quaternion(0,180,0,1);
                    }
                    if(action.direction == "left"){
                        usableEchos[echonum].transform.rotation = new Quaternion(0,0,0,1);
                    }
                }
                else if (action.actionType == Action.ActionType.Interact)
                {
                    gameLogic.processInteraction(usableEchos[echonum].id);
                }
            }
            echonum++;
        }
    }

    public void resetEchos(){
        //Clear out the actions to do and add in new ones. 
        actionsToDo = new List<Queue<Action>>();
        usableEchos = new List<Echo>();
        foreach(var i in storedActions){
            actionsToDo.Add(new Queue<Action>(i));
        }
        foreach(var i in echoes){
            usableEchos.Add(i.GetComponent<Echo>());
        }
        int assignID = 1;
        foreach(var i in usableEchos){
            i.id = assignID;
            assignID++;
            i.target = gameLogic.getScreenPosition(echoStartingPos);
            i.transform.position = gameLogic.getScreenPosition(echoStartingPos);
            i.transform.rotation = new Quaternion(0,180,0,1);
        }
    }

    public void resetLevel(){
        foreach(var i in echoes){
            Destroy(i);
        }
        echoes = new List<GameObject>();
        storedActions = new List<List<Action>>();
        actionsToDo = new List<Queue<Action>>();
        usableEchos = new List<Echo>();
        numEchoes = 0;
    }
}
