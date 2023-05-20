using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Vector3Int gridPosition;
    public EntityManager entityManager;
    public GameLogic gameLogic;


    public virtual void setPosition(){}
    public virtual void updateEntity(){}

}
