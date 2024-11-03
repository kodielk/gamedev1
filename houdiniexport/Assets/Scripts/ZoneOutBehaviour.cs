using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ZoneOutBehaviour : MonoBehaviour
{
    public Transform targetObject; // The object whose position we're tracking
    public float thresholdDistance = 1.0f; // Distance threshold in Unity units
    public IntData targetY; 
    public UnityEvent withinRangeEvent, outOfRangeEvent, delayedEvent, yThresholdEvent;

    private bool isWithinRange = false;
    private bool yEventTriggered = false;

    private void Update()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("No target object assigned to track.");
            return;
        }

        // Calculate the distance between this object's position and the target object's position
        float distance = Vector3.Distance(transform.position, targetObject.position);

        // Check if the object is within the specified range
        if (distance <= thresholdDistance)
        {
            if (!isWithinRange)
            {
                withinRangeEvent.Invoke();
                isWithinRange = true;
            }
        }
        else
        {
            if (isWithinRange)
            {
                outOfRangeEvent.Invoke();
                isWithinRange = false;
                StartCoroutine(InvokeDelayedEvent());
            }
        }

        // Check if the target object has reached or surpassed the target Y position
        if (targetObject.position.y >= targetY.Value && !yEventTriggered)
        {
            yThresholdEvent.Invoke();
            yEventTriggered = true; // Ensure the event only triggers once
        }
    }

    private IEnumerator InvokeDelayedEvent()
    {
        yield return new WaitForSeconds(0.5f);
        delayedEvent.Invoke();
    }
}