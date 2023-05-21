
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

    public Vector3 getScreenPosition(Vector3Int gridPosition){
        float x = grid.cellSize.x * (gridPosition.x + .5f);
        float y = grid.cellSize.y * (gridPosition.y + .5f);
        return new Vector3(x,y,0);
        //For entities in a list update entities
    }

    public Vector3Int getGridPosition(Vector3 position){
        int x = (int)Mathf.Round(position.x/grid.cellSize.x - .5f);
        int y = (int)Mathf.Round(position.y/grid.cellSize.y - .5f);
        return new Vector3Int(x,y,0);
    }

    public void processInteraction(int id){
        foreach(var i in interactables){
            var temp = i.GetComponent<Interactable>();
            if(temp!=null){
            temp.onInteract(id);
            }
        }
    }

    public void doEchoReset(){
        foreach(var i in interactables){
            var temp = i.GetComponent<Interactable>();
            if(temp!=null){
                temp.onEchoReset();
            }
        }
    }

    public void doLevelReset(){
        foreach(var i in interactables){
            var temp = i.GetComponent<Interactable>();
            if(temp!=null){
                temp.onLevelReset();
            }
        }
    }
    public void updateSurroundings(){
        foreach(var i in interactables){
            var temp = i.GetComponent<Interactable>();
            if(temp!=null){
                temp.onPlayerMove();
            }
        }
    }

}


