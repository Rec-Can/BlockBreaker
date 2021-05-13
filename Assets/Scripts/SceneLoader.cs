using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameStatus gameStatus;
    private void Awake()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }
    public void LoadNextScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        gameStatus.ResetGame();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
