using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2D : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    public bool SetActive;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        isGameOver = false;
       
    }

    private void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Selection");
    }
}
