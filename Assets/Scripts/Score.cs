using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance { get; private set; }

    [SerializeField] private TextMeshProUGUI currentScore, highScore;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = LoadHighScore().ToString();
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore()
    {
        score++;
        currentScore.text = score.ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (score > LoadHighScore())
            PlayerPrefs.SetInt("HighScore", score);
        highScore.text = LoadHighScore().ToString();
    }

    private int LoadHighScore() => PlayerPrefs.GetInt("HighScore", 0);
}
