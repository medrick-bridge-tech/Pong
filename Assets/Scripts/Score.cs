using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int _playerScore { get; set; }
    public int _aiScore { get; set; }

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Ball _ball;
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _aiScoreText;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            var ballRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            if (ballRigidbody.velocity.x < 0f)
            {
                _playerScore++;
                _playerScoreText.text = _playerScore.ToString();
            }
            else
            {
                _aiScore++;
                _aiScoreText.text = _aiScore.ToString();
            }
            
            _gameManager.GameState = GameStates.ReadyToStart;
            _ball.ResetPosition();
            _ball.StopMoving();

            if (_playerScore == 11 || _aiScore == 11)
            {
                _gameManager.EndGame();
            }
        }
    }
}
