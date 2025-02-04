using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollideEvent : MonoBehaviour
{
    public bool antiLooper;
    public bool secondAntiLooper;
    public bool inRange;
    public UnityEvent onTrackerCollision;
    public UnityEvent onChildCollision;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Tracker"))
        {
            inRange = true;
            Debug.Log("You're in range, ma friend");
            if (inRange)
            {
                if (!antiLooper)
                {
                    onTrackerCollision.Invoke();
                    antiLooper = true;
                }
            }
        }

        if (collision.gameObject.CompareTag("Child"))
        {
            inRange = true;
            Debug.Log("You're in range, ma friend");
            if (inRange)
            {
                if (!antiLooper)
                {
                    onChildCollision.Invoke();
                    antiLooper = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Tracker"))
        {
            antiLooper = false;
            inRange = false;

        }

        if (collision.gameObject.CompareTag("Child"))
        {
            antiLooper = false;
            inRange = false;

        }
    }


    public void SelfActivator()
    {
        this.gameObject.SetActive(true);
    }

    public void SelfDeactivator()
    {
        this.gameObject.SetActive(false);
    }
}

