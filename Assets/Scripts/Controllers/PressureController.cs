using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PressureController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI readout;

    public UnityEvent correctPressureEvent;

    public UnityEvent incorrectPressureEvent;

    private int pressure = 2;

    public int Pressure { get => pressure; }

    private int correctPressure = 12;

    public int CorrectPressure { get => correctPressure; }
    

    public void UpdateReadout(int modification)
    {
        pressure += modification;

        readout.text = pressure.ToString();

        CheckPressure();
    }

    private void Start()
    {
        readout.text = pressure.ToString();

        CheckPressure();
    }
    
    private void CheckPressure()
    {
        if(correctPressure == pressure)
        {
            correctPressureEvent?.Invoke();
        }
        else
        {
            incorrectPressureEvent?.Invoke();
        }
    }
}
