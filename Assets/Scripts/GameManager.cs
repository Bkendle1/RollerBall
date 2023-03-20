using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UI_Manager _scoreUI;
    [SerializeField] private UI_Manager _timerUI;
    [SerializeField] private UI_Manager _livesUI;
    [SerializeField] private float _levelStartTime = 60f;
    [SerializeField] private int maxLives = 3;
    [SerializeField] private string _EndSceneName = "End";
    [SerializeField] private string _WinSceneName = "Won";
    
    //allow external access to game manager but don't allow changes from them
    public static GameManager Instance { get; private set; }

    private int _score = 0;
    private float _timer = 0f;
    private int _lives = 0;
    
    void Awake()
    {
        //destroy instance if it's not referencing itself
        /*if (Instance != null && Instance != t    zhis)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }*/
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        
    }

    private void Start()
    {
        StartGame();
    }

    public void ResetGame()
    {
        _score = 0;
        _timer = _levelStartTime;
        _lives = maxLives;
        _scoreUI.UpdateUI(_score);
        _timerUI.UpdateUI(_timer);
        _livesUI.UpdateUI(_lives);
    }
    
    public void StartGame()
    {
        ResetGame();
        StartCoroutine(Countdown());
    }

    public void EndGame()
    {
        //stop timer
        Debug.Log("Game Over");
        StopCoroutine(Countdown());
        
        //go to game over scene
        SceneSwapper.LoadScene(_EndSceneName);
    }

    public void GameWon()
    {
        //save score
        PlayerPrefs.SetInt("HighScore", _score);
        //load winning scene
        SceneSwapper.LoadScene(_WinSceneName);
    }
    
    public void UpdateScore(int value)
    {
        _score += value;
        _scoreUI.UpdateUI(_score);
    }

    public void UpdateLives(int value)
    {
        _lives += value;
        if (_lives <= 0)
        {
            EndGame();
        }
        _livesUI.UpdateUI(_lives);
    }

    public void UpdateTimer(float value)
    {
        _timer += value;
        _scoreUI.UpdateUI(_timer);
    }

    //Timer
    IEnumerator Countdown()
    {
        //Decrement timer
        while (_timer > 0)
        {
            _timer--;
            _timerUI.UpdateUI(_timer);
            yield return new WaitForSeconds(1f); 
        }
        //When time runs out
        _timer = 0;
        _timerUI.UpdateUI(_timer);
        EndGame();
    }
    
}
