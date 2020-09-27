using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProcessComponent : MonoBehaviour , IComparable<ProcessComponent>
{
    [SerializeField]
    private int positionInProcess;

    public int PositionInProcess { get => positionInProcess; set => positionInProcess = value; }

    [SerializeField]
    private Task task;
        
    public Task Task { get => task; set => task = value; }

    public int CompareTo(ProcessComponent other)
    {
        if (this.positionInProcess > other.positionInProcess)
        {
            return 1;
        }
        else if (this.positionInProcess < other.positionInProcess)
        {
            return -1;
        }
        else
        {
            return 0;
        }           
    }

    public void Action()
    {
        if (Task.Active)
        {
            Task.CurrentAmount++;
            Task.Evaluate();
        }
    }
}
