
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameLogic : MonoBehaviour
{
    public GridLayout grid;
    public EntityManager entityManager;

    public GameObject[] interactables;
    
    // Start is called before the first frame update
    void Start()
    {
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
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
        //entityManager.updateEntities();
    }

    public Vector3 getScreenPosition(Vector3Int gridPosition){
        float x = grid.cellSize.x * (gridPosition.x + .5f);
        float y = grid.cellSize.y * (gridPosition.y + .5f);
        return new Vector3(x,y,0);
        //For entities in a list update entities
    }

    public void processInteraction(int id){
        foreach(var i in interactables){
            var temp = i.GetComponent<Interactable>();
            if(temp!=null){
            temp.onInteract(id);
            }
        }
    }





}


