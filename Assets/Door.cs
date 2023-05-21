using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen;
    public Switch switchObject; // Assign this in the inspector

    Collider2D myCollider; 

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        if (switchObject != null)
            switchObject.OnActivate += Toggle; // subscribe to the event
    }

    void OnDestroy()
    {
        if (switchObject != null)
            switchObject.OnActivate -= Toggle; // unsubscribe from the event
    }

    public void Toggle(){
        if (isOpen)
            Close();
        else
            Open();
    }

    // method to open the door
      public void Open(){
        isOpen = true;
        myCollider.isTrigger = true;
    }

    public void Close(){
        isOpen = false;
        myCollider.isTrigger = false;
    }
}
