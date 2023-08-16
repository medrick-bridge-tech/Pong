using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private ScoreManager _scoreManager;


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

    public void EndGame()
    {
        _winCanvas.SetActive(true);
        
        if (_scoreManager.playerScore > _scoreManager.aiScore)
        {
            _winText.text = "You win!";
        }
        else
        {
            _winText.text = "You lose!";
        }
    }
}
