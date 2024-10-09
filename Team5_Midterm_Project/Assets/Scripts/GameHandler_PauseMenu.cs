using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameHandler_PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer mixer;
    public static float volumeLevel = 1.0f;
    private Slider sliderVolumeCtrl;

    void Awake()
    {
        // Initially hide the pause menu
        pauseMenuUI.SetActive(false);
    }

    void Start()
    {
        pauseMenuUI.SetActive(false);
        GameisPaused = false;
        // Set the initial volume level if a slider exists in the scene
        GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
        if (sliderTemp != null)
        {
            sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
            sliderVolumeCtrl.value = volumeLevel;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        // Show the pause menu
        pauseMenuUI.SetActive(true);
        
        // Pause game time
        Time.timeScale = 0f;
        
        // Mute audio
        AudioListener.pause = true;

        // Set game pause state to true
        GameisPaused = true;
    }

    public void Resume()
    {
        // Hide the pause menu
        pauseMenuUI.SetActive(false);
        
        // Resume game time
        Time.timeScale = 1f;

        // Unmute audio
        AudioListener.pause = false;

        // Set game pause state to false
        GameisPaused = false;
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        GameisPaused = false;
        pauseMenuUI.SetActive(false);
        
        // Reset audio settings
        AudioListener.pause = false;

        // Please also reset all static variables here, for new games!
        SceneManager.LoadScene("MainMenu");
    }

    // Code for volume slider
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        volumeLevel = sliderValue;
    }
}
