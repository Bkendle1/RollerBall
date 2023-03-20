using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private UI_Manager finalScore;
    void Start()
    {
        finalScore.UpdateUI(PlayerPrefs.GetInt("HighScore"));
    }

}
