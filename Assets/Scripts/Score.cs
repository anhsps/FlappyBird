using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public static Score score;

    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI highScore;
    private int scores;

    private void Awake()
    {
        if (score == null)
            score = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScore.text = scores.ToString();

        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateHighScore()
    {
        if (scores > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", scores);
            highScore.text = scores.ToString();
        }
    }

    public void UpdateScore()
    {
        scores++;
        currentScore.text = scores.ToString();
        UpdateHighScore();
    }
}
