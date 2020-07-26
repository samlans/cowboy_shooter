using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicUI : MonoBehaviour 
{
    public Text score;
    private int count;

    void Start() 
    {

    }

    void Update() 
    {
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
        score.text = count.ToString();
        if (count <= 0 )
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
