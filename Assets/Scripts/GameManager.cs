using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private GameObject GameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
            PlayerPrefs.DeleteAll();
    }

    public void StartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void PauseGame()
    {
        Time.timeScale = 0f;
        FlyBehavior.instance.enabled = false;
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        FlyBehavior.instance.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void GameOver()
    {
        if (GameOverUI != null)
        {
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
        }
    }
}
