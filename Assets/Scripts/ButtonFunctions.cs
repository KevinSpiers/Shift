using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject menuButton;
    public void OpenMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        menuButton.SetActive(false);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        menuButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        menuButton.SetActive(true);
        Physics2D.gravity = new Vector3(0,-Mathf.Abs(Physics2D.gravity.y));
        Application.LoadLevel(0);
    }

    public void StartGame()
    {
        Application.LoadLevel(1);
    }
}
