using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public List<GameObject> task1Objects;
    public List<GameObject> task2Objects;
    public List<GameObject> task3Objects;

    public float proximityThreshold = 2.0f;

    public GameObject congratulationsUI;
    public Animator doorAnimator;
    public AudioSource mainAudioSource; // Add this variable

    private bool task1Completed = false;
    private bool task2Completed = false;
    private bool task3Completed = false;

    void Start()
    {
        congratulationsUI.SetActive(false);
    }

    void Update()
    {
        if (!task1Completed && CheckTaskCompletion(task1Objects))
        {
            task1Completed = true;
            Debug.Log("Task 1 completed.");
        }

        if (!task2Completed && CheckTaskCompletion(task2Objects))
        {
            task2Completed = true;
            Debug.Log("Task 2 completed.");
        }

        if (!task3Completed && CheckTaskCompletion(task3Objects))
        {
            task3Completed = true;
            Debug.Log("Task 3 completed.");
        }

        if (task1Completed && task2Completed && task3Completed)
        {
            congratulationsUI.SetActive(true);
            doorAnimator.Play("Opening");
            mainAudioSource.Play(); // Play the main audio
        }
    }

    private bool CheckTaskCompletion(List<GameObject> taskObjects)
    {
        for (int i = 0; i < taskObjects.Count - 1; i++)
        {
            for (int j = i + 1; j < taskObjects.Count; j++)
            {
                if (Vector3.Distance(taskObjects[i].transform.position, taskObjects[j].transform.position) > proximityThreshold)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
