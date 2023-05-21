using System;
using UnityEngine;

public class LeverSequence : MonoBehaviour
{
    public event Action OnCorrectSequence;
    public Lever[] levers;
    public bool[] correctSequence = { false, true, false };

    private void Start()
    {
        foreach (Lever lever in levers)
        {
            lever.OnStateChanged += CheckSequence;
        }
    }

    private void OnDestroy()
    {
        foreach (Lever lever in levers)
        {
            lever.OnStateChanged -= CheckSequence;
        }
    }

    private void CheckSequence()
    {
        for (int i = 0; i < levers.Length; i++)
        {
            if (levers[i].isOn != correctSequence[i])
            {
                return;
            }
        }

        OnCorrectSequence?.Invoke();
    }
}
