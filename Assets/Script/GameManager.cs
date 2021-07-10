using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        GameIsOver = false;
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game Over");
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver) { return; }
     
        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }
     
        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }
}
