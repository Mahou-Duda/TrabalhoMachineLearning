using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D ballBody;
    Vector3 startPosition;

    public Rigidbody2D BallBody { get => ballBody; protected set => ballBody = value; }

    public void Start()
    {
        startPosition = transform.position;
        if (!BallBody) BallBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("bateu");
        GetComponent<AudioSource>().Play();

        if (other.gameObject.name == "trigger")
        {
            UI.ScoreValue += 1;
            //ResetBall();
        }

    }

    public void ResetBall()
    {
        transform.position = startPosition;
        BallBody.velocity = Vector2.zero;
    }
}
