using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject pauseButton;

    private void Awake()
    {
        //check biến tĩnh manager đã dc khởi tạo chưa. đảm bảo chỉ có 1dtg GameManager duy nhất tồn tại trong app
        if (manager == null)//nếu manager chưa dc khởi tạo(=null)
            manager = this; //thì gán this_đối tượng htai của lớp này
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
        //SceneManager.LoadScene("GamePlay");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }

    public void GameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f;//đóng băng tg
        }
        pauseButton.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
