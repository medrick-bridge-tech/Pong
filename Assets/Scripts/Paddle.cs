using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private const float MIN_Y_POS = -3.93f;
    private const float MAX_Y_POS = 3.93f;
    
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private GameManager _gameManager;

    
    void Update()
    {
        VerticalMove();
    }

    private void VerticalMove()
    {
        if (_gameManager.GameState == GameStates.Playing)
        {
            var verticalMovement = Input.GetAxis("Vertical") * _verticalSpeed * Time.deltaTime;
        
            transform.position = new Vector3(transform.position.x, 
                Mathf.Clamp(transform.position.y + verticalMovement, MIN_Y_POS, MAX_Y_POS), transform.position.z);
        }
    }
    
    public void ResetPosition()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}
