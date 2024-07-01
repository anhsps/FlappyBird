using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject pauseButton;

    private void Awake()
    {
        if (manager == null)
            manager = this;
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        FlyBehavior.fly.enabled = false;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        FlyBehavior.fly.enabled = true;
    }

    public void GameOver()
    {
        if (GameOverUI != null && pauseButton != null)
        {
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
            pauseButton.SetActive(false);
        }
    }
}
