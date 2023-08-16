using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _startingSpeed;
    [SerializeField] private GameManager _gameManager;
    
    private float _randomX;
    private float _randomY;
    private Vector2 _randomVector;
    private Rigidbody2D _ballRigidbody;


    void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
    }

    public void StopMoving()
    {
        _ballRigidbody.velocity = Vector2.zero;
    }
    
    public void UpdateRandomVector()
    {
        _randomX = Random.Range(-1f, 1f);
        _randomY = Random.Range(-1f, 1f);
        _randomVector = new Vector2(_randomX, _randomY).normalized;
    }

    public void StartMoving()
    {
        _gameManager.GameState = GameStates.Playing;
        _ballRigidbody.velocity = _randomVector * _startingSpeed;
    }
}
