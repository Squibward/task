using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractWithObject : MonoBehaviour
{
    public UnityEvent action;

    [SerializeField]
    private string logMessage;

    private void OnMouseUp()
    {
        print("Clicked");

        action?.Invoke();

        Records.AddToRecord(logMessage);
    }
}
