using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject PauseMenuUi;
    public GameObject player;
    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("StartButton"))
        {
            Pause();
        }
    }

    public void Resume()
    {
        Time.timeScale=1f;
        PauseMenuUi.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale=0f;
        PauseMenuUi.SetActive(true);
    }
    public void PlayAgain()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu(string _name)
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(_name);
    }
    public void LoadScene(string n)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(n);
    }
    public void HomeButton()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(0);
    }
    public void PlayGame()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
