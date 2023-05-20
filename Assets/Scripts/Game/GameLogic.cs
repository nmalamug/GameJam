
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameLogic : MonoBehaviour
{
    public GridLayout grid;
    public EntityManager entityManager;


    
    // Start is called before the first frame update
    void Start()
    {
        
        //StartNewLevelIteration(); // Start the first iteration immediately
    }
    void Update()
    {

    }

    public void updateSurroundings(){
        /*
            Implement code here to interact, update enemy
            positions, update positions of echoes, update level state
        */
        entityManager.updateEntities();
    }

    public Vector3 getScreenPosition(Vector3Int gridPosition){
        float x = grid.cellSize.x * (gridPosition.x + .5f);
        float y = grid.cellSize.y * (gridPosition.y + .5f);
        return new Vector3(x,y,0);
        //For entities in a list update entities
    }

   public bool isAdjacentInteractable(Vector3Int gridpos){
       /*
           Get Player grid position through player.gridPosition.x/y - x or y


           For all entities in list
           For all directions adjacent to player
           Check if interactable
       */
       //For entities in list check if interactable by character


       //For now, return true
       return true;
   }


   public bool isValidMove(string moveDirection){
       //Use this to determine if player can move there.
       switch (moveDirection){
           case "up":
           /*
               Pseudocode:
               for all obstacles/enemies:
               if(player.gridPosition.x != [obstacle x] && player.gridPosition.y+1 != [obstacle y]){
                   //Do something
               }


               Can maybe circumvent this by including tilemap itself?
           */
               //Insert code for checking direction validity.
             break;
           case "down":


             break;
           case "left":


             break;
           case "right":


             break;
       }
      
       //Right now just returns true
       return true;
   }


}


