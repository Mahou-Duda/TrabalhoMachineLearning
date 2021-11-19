using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    Vector3 startPosition;

    public void Start()
    {
        startPosition = transform.position;       
    }

    public void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("bateu");
        GetComponent<AudioSource>().Play();

        if(other.gameObject.name == "trigger")
        {
            UI.ScoreValue += 1;
            transform.position = startPosition;
        }

    }
}
