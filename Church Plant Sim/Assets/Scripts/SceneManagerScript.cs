using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    //public GameObject pauseCanvas;
    //public GameObject gameOverCanvas;
    //public GameObject onScreenUICanvas;

    public bool isPaused = false;
    public float timeScaleVal = 1f;

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrResume();
        }
        
    }

    public void loadlevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeTime(float timeVal)
    {
        Time.timeScale = timeVal;
        timeScaleVal = timeVal;
    }

    public void PauseOrResume()
    {
        if(Time.timeScale != 0 || !isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            GameEvents.instance.PauseEvent();
        }
        else if(Time.timeScale == 0 || isPaused)
        {
            isPaused = false;
            Time.timeScale = timeScaleVal;
            GameEvents.instance.PauseEvent();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
