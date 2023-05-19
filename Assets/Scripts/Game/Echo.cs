using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    public List<Action> actions = new List<Action>();
    GameLogic gameLogic ;
    public Echo(List<Action> actions)
    {
        this.actions = actions;
    }

    void Update()
    {
        if (actions.Count > 0)
        {
            Action action = actions[0];
            actions.RemoveAt(0);

            if (action.actionType == Action.ActionType.Move)
            {
                // Echo moves to the recorded position
                transform.position = gameLogic.getScreenPosition(action.position);
            }
            else if (action.actionType == Action.ActionType.Interact)
            {
                // Echo interacts with the recorded position
                // Code to interact with objects goes here
            }
        }
    }
}
