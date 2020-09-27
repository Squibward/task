using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class HitKey : MonoBehaviour
{
    public UnityEvent action;

    [SerializeField]
    private string logMessage;

    [SerializeField]
    private PressureController pressureController;

    [SerializeField]
    private GameObject errorPrefab;

    [SerializeField]
    private string errorText;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.A))
        {
            if(pressureController.Pressure == pressureController.CorrectPressure)
            {
                action?.Invoke();
            }      
            else
            {
                GameObject error = GameObject.Instantiate(errorPrefab);

                error.transform.Find("ErrorText").GetComponent<TextMeshProUGUI>().text = errorText;
            }

            Records.AddToRecord(logMessage);            
        }        
    }
}
