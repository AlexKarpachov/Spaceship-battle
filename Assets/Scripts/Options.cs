using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
   // Was not used in the game [SerializeField] AudioMixer audioMixer;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    // Reference to the final point object that triggers the end of the level
    [SerializeField] GameObject finalPoint; 

    bool gameIsPaused = false;

    private void Start()
    {
        // Enable the final point object after a delay of 1 second
        StartCoroutine(FinalPointEnabled());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    IEnumerator FinalPointEnabled()
    {
        yield return new WaitForSeconds(1.0f);
        finalPoint.gameObject.SetActive(true);
    }

    // Method to resume the game from a paused state
    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }
    public void PauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    // Method to load the main menu scene
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }


    /*
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void setFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
    */
}
