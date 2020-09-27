using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject summaryScreen;

    private TextMeshProUGUI text;

    public void ShowSummary()
    {
        GameObject summaryClone = GameObject.Instantiate(summaryScreen);

        text = summaryClone.GetComponentInChildren<TextMeshProUGUI>();

        ShowText();
    }

    private void ShowText()
    {
        foreach(string log in Records.logs)
        {
            text.text += log + "\n";
        }        
    }
}
