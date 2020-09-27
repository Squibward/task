using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> keys = new List<GameObject>();

    [SerializeField]
    private string logMessage;

    public UnityEvent action;

    private int keysRemoved = 0;

    private int keyTotal = 0;

    public void RemoveKey(GameObject key)
    {
        keys.Remove(key);

        Destroy(key);

        Records.AddToRecord(logMessage + " " + key.name);

        keysRemoved += 1;

        Check();
    }

    private void Start()
    {
        keyTotal = keys.Count;
    }

    private void OnEnable()
    {
        TaskManager.onTaskCheck += Check;
    }

    private void OnDisable()
    {
        TaskManager.onTaskCheck -= Check;
    }

    private void Check()
    {
        if (keys.Count == 0)
        {
            action?.Invoke();
        }
    }
}
