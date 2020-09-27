using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task 
{
    public delegate void OnCompleted();
    public static OnCompleted onCompleted;

    public bool Active;
    public bool Completed;
    public string Description;
    public int CurrentAmount;
    public int RequiredAmount;     

    public void Evaluate()
    {
        if(CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
        Active = false;

        if(onCompleted != null)
        {
            onCompleted();
        }
    }
}
