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
                    usableEchos[echonum].transform.position = gameLogic.getScreenPosition(action.position);
                }
                else if (action.actionType == Action.ActionType.Interact)
                {
                    // Code to interact with objects goes here
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
        foreach(var i in usableEchos){
            i.transform.position = gameLogic.getScreenPosition(echoStartingPos);
        }
    }
}
