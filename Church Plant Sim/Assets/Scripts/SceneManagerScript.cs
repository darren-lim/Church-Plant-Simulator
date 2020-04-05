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

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        /***
        if (Input.GetKeyDown(KeyCode.Escape) && pauseCanvas != null)
        {
            PauseOrResume();
        }
        ***/
    }

    public void loadlevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseOrResume()
    {
        try
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                isPaused = false;
            }
            //pauseCanvas.SetActive(isPaused);
        }
        catch
        {
            Debug.Log("Esc No Work");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
