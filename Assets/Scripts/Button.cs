using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour { 


    //string nomeCena;
    // Start is called before the first frame update
    public void Gatinho()
    {
       SceneManager.LoadScene("SampleScene");             
    }
}
