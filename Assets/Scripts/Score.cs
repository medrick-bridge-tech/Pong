using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _playerScore;
    private int _aiScore;

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Ball _ball;
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            var ballRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            
            if (ballRigidbody.velocity.x < 0f)
            {
                _playerScore++;
                _scoreManager.playerScore++;
                _scoreManager.UpdateScoreboard();
            }
            else
            {
                _aiScore++;
                _scoreManager.aiScore++;
                _scoreManager.UpdateScoreboard();
            }
            
            _gameManager.GameState = GameStates.ReadyToStart;
            _ball.ResetPosition();
            _ball.StopMoving();

            if (_playerScore == 2 || _aiScore == 2)
            {
                _gameManager.EndGame();
            }
        }
    }
}
