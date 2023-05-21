using System;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isOn = false;
    public event Action OnStateChanged;

    public void ChangeState()
    {
        isOn = !isOn;
        Debug.Log("Lever state has been changed to: " + (isOn ? "On" : "Off"));
        OnStateChanged?.Invoke();
    }
}

