
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameLogic : MonoBehaviour
{
    public GridLayout grid;
    public GridPlayer player;
    public EntityManager entityManager;
    
    // Start is called before the first frame update
    void Start()
    {

    }


   public int maxIterations =  1; // Maximum number of iterations for testing
   private int currentIteration = 0; // Keep track of current iteration

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



   public GridLayout grid;
   public GridPlayer player;
   public float tileWidth;
   public float tileHeight;
  
   // Start is called before the first frame update
   void Start()
   {
       StartNewLevelIteration(); // Start the first iteration immediately
       tileWidth = grid.cellSize.x;
       tileHeight = grid.cellSize.y;
   }


  void Update()
    {
        if (CheckLevelCompleted() && currentIteration < maxIterations)
        {
            StartNewLevelIteration();
            currentIteration++;
        }
    }



   public bool CheckLevelCompleted() // Placeholder, replace with your actual level completion logic
   {
       // For testing purposes, let's say a level is completed after 10 seconds
       return Time.timeSinceLevelLoad >= 1000;
   }


  
    public Sprite echoSprite; // Assign your echo sprite in the Unity Inspector

    public void StartNewLevelIteration()
{
    // Create a new GameObject for the Echo
    GameObject echoObject = new GameObject("Echo");
    echoObject.transform.position = player.transform.position;

    // Add the SpriteRenderer component and assign the echo sprite
    SpriteRenderer spriteRenderer = echoObject.AddComponent<SpriteRenderer>();
    spriteRenderer.sprite = echoSprite;

    // Add the Echo script to the new object
    Echo echo = echoObject.AddComponent<Echo>();

    // Pass the GameLogic instance to the Echo
    echo.SetGameLogic(this);
    
    // Give the Echo the player's actions
    echo.SetActions(new List<Action>(player.actions));

    // Reset the player's actions for the new iteration
    player.actions.Clear();
}

   public void updateSurroundings(){
       /*
           Implement code here to interact, update enemy
           positions, update positions of echoes, update level state
       */
       Debug.Log("Updated!");
   }


   public Vector3 getScreenPosition(Vector3Int gridPosition){
       float x = tileWidth * (gridPosition.x + .5f);
       float y = tileHeight * (gridPosition.y + .5f);
       return new Vector3(x,y,0);
       //For entities in a list update entities
   }


   public bool isAdjacentInteractable(){
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


