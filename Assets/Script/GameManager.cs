using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded) { return; }
        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }
}
