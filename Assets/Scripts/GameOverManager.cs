using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] public GameObject gameOverScreen;
    public void SetGameOver()
    {
        gameOverScreen.SetActive(true);    
    }
    public void RestarGame()
    {
        SceneManager.LoadScene(0);
        PlayerControler.isPlayerDead = false;
    }
}
