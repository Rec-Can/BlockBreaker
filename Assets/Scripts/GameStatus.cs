using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int currentScore;
    [SerializeField] int pointsForBlock = 100;
    [SerializeField] Text scoreText;
    [SerializeField] bool isAutoPlay = false;

    private void Awake()
    {
        // Singlenton Pattern
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsForBlock;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlay()
    {
        return isAutoPlay;
    }
}
