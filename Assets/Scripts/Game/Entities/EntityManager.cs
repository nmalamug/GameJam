using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public List<GameObject> gameEntities;
    public GameObject basicEnemy;
    public GameObject aSwitch;

    // Start is called before the first frame update
    void Awake()
    {
        //Use an array of game entities
        createBasicEnemy(new Vector3Int(3,3,0));
        createSwitch(new Vector3Int(5,5,0));
        createBasicEnemy(new Vector3Int(-3,-3,0));
    }

    //Functions to add game entities to the list
    public void createSwitch(Vector3Int position){
        gameEntities.Add(Instantiate(aSwitch, position, transform.rotation));
    }

    public void createBasicEnemy(Vector3Int position){
        gameEntities.Add(Instantiate(basicEnemy, position, transform.rotation));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEntities(){
        //Updates the entities. 
        foreach(var i in gameEntities){
            Entity temp = i.GetComponent<Entity>();
            temp.updateEntity();
        }
    }
}

