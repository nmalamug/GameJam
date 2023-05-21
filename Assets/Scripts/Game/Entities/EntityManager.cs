using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public List<GameObject> gameEntities;
    
    public void updateEntities(){
        //Updates the entities. 
        foreach(var i in gameEntities){
            Entity temp = i.GetComponent<Entity>();
            temp.updateEntity();
        }
    }
}

