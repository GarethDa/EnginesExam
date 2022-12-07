using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoss : MonoBehaviour
{
    bool gameWon = false;
    bool gameLost = false;

    public int maxScore = 10;
    int score = 0;

    public int health = 3;

    public GameObject winTextObj;
    public GameObject loseTextObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score == maxScore)
        {
            gameWon = true;
        }

        if (health <= 0)
        {
            gameLost = true;
        }

        if (gameWon)
        {
            winTextObj.SetActive(true);
            Time.timeScale = 0f;
        }

        if (gameLost)
        {
            loseTextObj.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void WinGame()
    {
        gameWon = true;
    }

    public void LoseGame()
    {
        gameLost = true;
    }

    public void AddScore()
    {
        score++;
    }

    public void LoseHealth()
    {
        health--;
    }
}
