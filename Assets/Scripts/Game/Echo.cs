using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
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
=======

public class Echo : MonoBehaviour
{
   public Sprite echoSprite; // Public variable to assign your sprite in the inspector
   private SpriteRenderer spriteRenderer;


void Start()
{
   spriteRenderer = GetComponent<SpriteRenderer>();
   if (spriteRenderer == null)
   {
       Debug.LogError("Failed to add/get SpriteRenderer");
       return;
   }
}

public void SetGameLogic(GameLogic gameLogic)
{
    this.gameLogic = gameLogic;
}



   GameLogic gameLogic;
   Queue<Action> actions;


   public void SetActions(List<Action> actions)
   {
       this.actions = new Queue<Action>(actions);

   }


   void Update()
   {
       if (actions != null && actions.Count > 0)
       {
           Action action = actions.Dequeue();


           if (action.actionType == Action.ActionType.Move)
           {

               transform.position = gameLogic.getScreenPosition(action.position);
           }
           else if (action.actionType == Action.ActionType.Interact)
           {
               // Code to interact with objects goes here
           }
       }
   }
}






>>>>>>> Stashed changes
