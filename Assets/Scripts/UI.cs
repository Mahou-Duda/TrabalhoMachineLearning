using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    Text texto;
    public static int ScoreValue;
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = "Score: " + ScoreValue;
    }
}
