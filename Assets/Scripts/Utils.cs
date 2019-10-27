using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour
{
    public void Restart()
    {
        int idx = 1;
        if (SceneManager.GetActiveScene().buildIndex > 1)
            idx = SceneManager.GetActiveScene().buildIndex - 1;

        SceneManager.LoadScene(idx);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
