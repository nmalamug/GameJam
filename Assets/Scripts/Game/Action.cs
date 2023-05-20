using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class Action
{
    public enum ActionType { Move, Interact }

    public ActionType actionType;
    public Vector3Int position;
    public string direction;

    public Action(ActionType actionType, Vector3Int position, string direction = "")
    {
        this.actionType = actionType;
        this.position = position;
        this.direction = direction;
    }
}
=======

public class Action
{
   public enum ActionType { Move, Interact }


   public ActionType actionType;
   public Vector3Int position;
   public string direction;


   public Action(ActionType actionType, Vector3Int position, string direction = "")
   {
       this.actionType = actionType;
       this.position = position;
       this.direction = direction;
   }
}





>>>>>>> Stashed changes
