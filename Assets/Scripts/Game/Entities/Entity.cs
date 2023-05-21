using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Outline code for entity objects
    public Vector3Int gridPosition;
    public Vector3Int startingPosition;
    public GameLogic gameLogic;
    float speed = 15f;
    public void init(){
        getLogic();
        snapToGrid();
    }
    public void snapToGrid(){
        transform.position = gameLogic.getScreenPosition(gridPosition);
    }

    public void getLogic(){
        gameLogic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>();
        gridPosition = gameLogic.getGridPosition(transform.position);
        startingPosition = gridPosition;
    }

    void FixedUpdate(){
        transform.position = Vector3.MoveTowards(transform.position,gameLogic.getScreenPosition(gridPosition), speed*Time.deltaTime);
    }
}
