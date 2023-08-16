using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    ReadyToStart,
    End,
    Playing
}

public class GameManager : MonoBehaviour
{
    public GameStates GameState { get; set; }

    [SerializeField] private Ball _ball;
    [SerializeField] private Paddle _paddle;
    
    
    void Start()
    {
        GameState = GameStates.ReadyToStart;
    }

    void Update()
    {
        if (GameState == GameStates.ReadyToStart && Input.GetKeyDown(KeyCode.Space))
        {
            _ball.UpdateRandomVector();
            _ball.StartMoving();
            GameState = GameStates.Playing;
        }

        if (GameState == GameStates.ReadyToStart)
        {
            _paddle.ResetPosition();
        }
    }
}
