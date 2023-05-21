using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Echo : MonoBehaviour
{
    public Vector3 target;
    public int id;
    void Start()
    {

    }

    void FixedUpdate(){
        transform.position = Vector3.MoveTowards(transform.position,target, 15f*Time.deltaTime);
    }

}






