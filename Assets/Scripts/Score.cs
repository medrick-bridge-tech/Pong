using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _playerScore;
    private int _aiScore;

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Ball _ball;
    [SerializeField] private GameObject goalVFX;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Color color;
            var ballRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
               
            if (ballRigidbody.velocity.x < 0f)
            {
                _playerScore++;
                _scoreManager.playerScore++;
                _scoreManager.UpdateScoreboard();
                color = Color.blue;
            }
            else
            {
                _aiScore++;
                _scoreManager.aiScore++;
                _scoreManager.UpdateScoreboard();
                color = Color.red;
            }

            GameObject vfx = Instantiate(goalVFX, ballRigidbody.transform.position, quaternion.identity);
            Destroy(vfx,1f);
            _gameManager.GameState = GameStates.ReadyToStart;
            _ball.ResetPosition();
            _ball.StopMoving();

            if (_playerScore == 11 || _aiScore == 11)
            {
                _gameManager.EndGame();
            }
            
            FindObjectOfType<Shaker>().Shake(2f,1.29f,2f);
        }
    }
}
