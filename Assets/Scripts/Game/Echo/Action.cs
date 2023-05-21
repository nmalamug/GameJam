using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action
{
    public enum ActionType { Move, Interact }

    public ActionType actionType;
    public Vector3Int position;
    public string direction;

    public action(ActionType actionType, Vector3Int position, string direction = "")
    {
        this.actionType = actionType;
        this.position = position;
        this.direction = direction;
    }
}
