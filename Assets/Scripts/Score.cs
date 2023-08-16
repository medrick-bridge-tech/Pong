using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _playerScore;
    private int _aiScore;
    
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            var ballRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            if (ballRigidbody.velocity.x < 0f)
            {
                _playerScore++;
                Debug.Log($"Player score: {_playerScore}");
            }
            else
            {
                _aiScore++;
                Debug.Log($"AI score: {_aiScore}");
            }
        }
    }
}
