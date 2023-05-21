using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Entity
{
    public static List<Switch> AllSwitches = new List<Switch>();
    public delegate void SwitchAction();
    public event SwitchAction OnActivate;
    public bool isActive = false; 

    //For every new entity just copy this script
    //Every entity has a gridPosition
    //For example, to move - Do grid position++ and in the Fixed Update, 
    //Do transform.position = Vector3.movtowards(..,...,...);
     public void Activate(){
        isActive = !isActive;
        Debug.Log("switch has been flipped");

        if (OnActivate != null)
            OnActivate.Invoke(); // Invoke the event when the switch is activated
    }

    
    void Start()
    {
        init(); 
        AllSwitches.Add(this);
    }
    void OnDestroy()
    {
        AllSwitches.Remove(this);
    }

    public static bool CheckAllSwitches()
    {
        foreach (Switch s in AllSwitches)
        {
            if (!s.isActive) return false;
        }
        return true;
    }

    public void echoUpdate(){
        gridPosition.x++;
    }

    public void levelReset(){
        gridPosition = startingPosition;
        snapToGrid();
        isActive = false;
    }

    public void playerMove(){
        gridPosition.y--;
    }

    // Start is called before the first frame update


}
