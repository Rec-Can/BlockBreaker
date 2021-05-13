using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] int worldPointsInUnits = 16;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    //cached reference
    Ball ball;
    GameStatus gameStatus;

    private void Awake()
    {
        ball = FindObjectOfType<Ball>();
        gameStatus = FindObjectOfType<GameStatus>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 paddlePos = new Vector2(GetXPos(), transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gameStatus.IsAutoPlay())
        {
            return ball.transform.position.x;
        }
        else
        {
            float mousePosInUnit = Input.mousePosition.x / Screen.width * worldPointsInUnits;
            return mousePosInUnit;
        }
    }
}
