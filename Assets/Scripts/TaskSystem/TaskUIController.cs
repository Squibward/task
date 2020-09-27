using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI mainText;

    [SerializeField]
    private TextMeshProUGUI taskLogText;

    private string taskDescription;

    private bool tasksStarted = false;

    public void OnNewTask(string taskDescription)
    {
        this.taskDescription = taskDescription;        

        StopCoroutine("ShowTaskDescription");
        
        StartCoroutine("Wait");       
    }
    
    public void OnTaskCompleted()
    {
        StopCoroutine("ShowTaskDescription");

        mainText.text = "Task Completed";

        taskLogText.text = null;
    }

    public void AllTasksCompleted()
    {
        mainText.text = "All Tasks Completed";

        taskLogText.text = null;
    }

    private void UpdateTaskLog()
    {
        taskLogText.text = taskDescription;        
    }

    private IEnumerator ShowTaskDescription()
    {
        mainText.text = taskDescription;        

        yield return new WaitForSeconds(3);

        mainText.text = null;

        UpdateTaskLog();
    }

    private IEnumerator Wait()
    {
        if(tasksStarted)
        {
            yield return new WaitForSeconds(2);
        }
        else
        {
            yield return null;
        }       

        StartCoroutine("ShowTaskDescription");

        tasksStarted = true;
    }
}
