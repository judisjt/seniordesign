using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void BackToMenuFromTutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void QuitGame() {

        Application.Quit();

        Debug.Log("QUIT");

    }
    public void GoBackToMenu() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

}
