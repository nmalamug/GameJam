using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        getLogic();
        gridPosition = new Vector3Int((int)transform.position.x, (int)transform.position.y,0);
        setPosition();
    }

    public void getLogic(){
        entityManager = GameObject.FindGameObjectWithTag("EntityManager").GetComponent<EntityManager>();
        gameLogic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>();
    }
    public override void updateEntity(){
        Debug.Log("Switch is Here!");
    }
    public override void setPosition()
    {
        transform.position = gameLogic.getScreenPosition(gridPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
