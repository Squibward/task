using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TaskManager : MonoBehaviour
{

    public delegate void TaskCheck();
    public static TaskCheck onTaskCheck;

    [SerializeField]
    private TaskUIController uIController;

    private List<ProcessComponent> processes = new List<ProcessComponent>();

    private int currentTaskNo = 0;

    public void NextTask()
    {
        if(currentTaskNo >= processes.Count)
        {
            uIController.AllTasksCompleted();

            return;
        }

        processes[currentTaskNo].Task.Active = true;        
        uIController.OnNewTask(processes[currentTaskNo].Task.Description);

        StartCoroutine("Wait");
    }

    private void TaskCompleted()
    {
        Records.AddToRecord(processes[currentTaskNo].Task.Description + " Completed");

        uIController.OnTaskCompleted();

        currentTaskNo++;

        NextTask();
    }

    private void Start()
    {
        ProcessComponent [] tempProcesses = FindObjectsOfType<ProcessComponent>();

        //print(tempProcesses.Length);

        foreach(ProcessComponent pc in tempProcesses)
        {
            processes.Add(pc);

            //print(pc.PositionInProcess);
        }

        processes.Sort();

        foreach (ProcessComponent pc in processes)
        {
            print(pc.PositionInProcess);
        }
    }

    private void OnEnable()
    {
        Task.onCompleted += TaskCompleted;
    }

    private void OnDisable()
    {
        Task.onCompleted -= TaskCompleted;
    }

    private IEnumerator Wait()
    {       
         yield return new WaitForSeconds(4);

        if (onTaskCheck != null)
        {
            onTaskCheck();
        }
    }
}
