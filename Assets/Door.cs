using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Entity 
{
    public bool isOpen;
    public Switch switchObject; // Assign this in the inspector
    public LeverSequence leverSequence; // assign this in the inspector

    Collider2D myCollider; 

    void Start()
    {
        init();
        myCollider = GetComponent<Collider2D>();
        if (leverSequence != null)
            leverSequence.OnCorrectSequence += Toggle; // subscribe to the lever sequence event
        if (switchObject != null)
            switchObject.OnActivate += Toggle; // subscribe to the switch event
    }

    void OnDestroy()
    {
        if (leverSequence != null)
            leverSequence.OnCorrectSequence -= Toggle; // unsubscribe from the lever sequence event
        if (switchObject != null)
            switchObject.OnActivate -= Toggle; // unsubscribe from the switch event
    }

    public void Toggle()
    {
        isOpen = !isOpen;

        myCollider.enabled = !isOpen;
        Debug.Log("Door state has been changed to: " + (isOpen ? "Open" : "Closed"));
    }
}
