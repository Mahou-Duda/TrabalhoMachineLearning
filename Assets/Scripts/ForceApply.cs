using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceApply : MonoBehaviour
{
    //public??
    Rigidbody2D plataformaRigidbody;
    //public float movespeed = 500;
    public KeyCode key;
    Vector3 pos; 
    // Start is called before the first frame update
    public void Awake()
    {
        pos = transform.position;

        plataformaRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(plataformaRigidbody != null)
        {
            ApplyInput();
        }
        else
        {
            Debug.LogWarning("Sem Rigibody" + gameObject.name);
        }
    }

    public void ApplyInput()
    {
        //float xInput = Input.GetAxis("X");
        //float yInput = Input.GetAxis("Y");

        //float xForce = xInput * movespeed * Time.deltaTime;


        //    \/\/\/used old input system
        //if(Input.GetKeyDown(key))
        //{
        //    if (pos.y <= 0)
        //    {
        //        Vector2 force = new Vector2(0, 1000);

        //        plataformaRigidbody.AddForce(force);
        //    }
        //}

       
    }
}
