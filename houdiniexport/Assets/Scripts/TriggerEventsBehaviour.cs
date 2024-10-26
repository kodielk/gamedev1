using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventsBehaviour : MonoEventsBehavior
{
    public GameAction triggerEnterAction, triggerEnterRepeatAction, triggerEnterEndAction, triggerExitAction;
    public UnityEvent triggerEnterEvent, triggerEnterRepeatEvent, triggerEnterEndEvent, triggerExitEvent;
    private WaitForSeconds waitForTriggerEnterObj, waitForTriggerRepeatObj;
    public float triggerHoldTime = 0.0f, repeatHoldTime = 0.01f, exitHoldTime = 0.01f;
    public bool canRepeat;
    public int repeatTimes = 10;

    protected override void Awake()
    {
        base.Awake();
        waitForTriggerEnterObj = new WaitForSeconds(triggerHoldTime);
        waitForTriggerRepeatObj = new WaitForSeconds(repeatHoldTime);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        // Initial trigger hold
        yield return waitForTriggerEnterObj;
        triggerEnterEvent.Invoke();
        triggerEnterAction?.RaiseNoArgs();

        // Repeat action if enabled
        if (canRepeat)
        {
            for (int i = 0; i < repeatTimes; i++)
            {
                yield return waitForTriggerRepeatObj;
                triggerEnterRepeatEvent.Invoke();
                triggerEnterRepeatAction?.RaiseNoArgs();
            }
        }

        // End trigger action
        triggerEnterEndEvent.Invoke();
        triggerEnterEndAction?.RaiseNoArgs();
    }

    private void OnTriggerExit(Collider other)
    {
        // Trigger exit events/actions immediately on exit
        triggerExitEvent.Invoke();
        triggerExitAction?.RaiseNoArgs();
    }
}
