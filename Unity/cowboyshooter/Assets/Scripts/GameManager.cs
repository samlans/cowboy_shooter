using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 10f;
    public GameObject completeLevelUI;
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            completeLevelUI.SetActive(true);
            Invoke("Restart", restartDelay);

        }
    }
    
    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}