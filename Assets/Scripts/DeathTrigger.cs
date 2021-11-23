using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent onTriggered = new UnityEngine.Events.UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Trigger Entered");
        if (collision.CompareTag("Gato"))
        {
            //print("Gato Entered");
            onTriggered?.Invoke();
        }
    }
}
