using UnityEngine;

public class Task : MonoBehaviour
{
    public bool isComplete;
    public Task[] otherObjects;
    public float proximityThreshold = 1.0f;

    void Update()
    {
        if (!isComplete)
        {
            bool allClose = true;

            foreach (Task otherObject in otherObjects)
            {
                float distance = Vector3.Distance(transform.position, otherObject.transform.position);
                if (distance > proximityThreshold)
                {
                    allClose = false;
                    break;
                }
            }

            if (allClose)
            {
                isComplete = true;
            }
        }
    }
}
