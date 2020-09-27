using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Records
{
    public static List<string> logs = new List<string>();

    public static void AddToRecord(string addedLog)
    {
        logs.Add(addedLog);
    }
}
