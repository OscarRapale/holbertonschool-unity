using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerExit(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            Timer timer = other.GetComponent<Timer>();
            if (timer != null)
            {
                timer.StartTimer();
                triggered = true;
            }
        }
    }
}
