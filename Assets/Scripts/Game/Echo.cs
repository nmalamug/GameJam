using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine;


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






