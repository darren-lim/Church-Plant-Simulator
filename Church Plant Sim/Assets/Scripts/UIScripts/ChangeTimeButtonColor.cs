using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTimeButtonColor : MonoBehaviour
{
    public Button pauseButton;
    public Button playButton;
    public Button doubleButton;

    private Image pauseImage;
    private Image playImage;
    private Image doubleImage;

    // Start is called before the first frame update
    void Start()
    {
        pauseImage = pauseButton.GetComponent<Image>();
        playImage = playButton.GetComponent<Image>();
        doubleImage = doubleButton.GetComponent<Image>();
    }

    public void onPauseButton()
    {
        pauseImage.color = Color.green;
        playImage.color = Color.white;
        doubleImage.color = Color.white;
    }

    public void onPlayButton()
    {
        pauseImage.color = Color.white;
        playImage.color = Color.green;
        doubleImage.color = Color.white;
    }

    public void onDoubleButton()
    {
        pauseImage.color = Color.white;
        playImage.color = Color.white;
        doubleImage.color = Color.green;
    }
}
