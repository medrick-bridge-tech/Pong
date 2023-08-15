using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _startingSpeed;

    private bool _gameHasStarted;
    private float _randomX;
    private float _randomY;
    private Vector2 _randomVector;
    private Rigidbody2D _ballRigidbody;


    void Start()
    {
        _randomX = Random.Range(-1f, 1f);
        _randomY = Random.Range(-1f, 1f);
        _randomVector = new Vector2(_randomX, _randomY).normalized;

        _ballRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!_gameHasStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartMoving();
        }
    }

    private void StartMoving()
    {
        _gameHasStarted = true;
        _ballRigidbody.velocity = _randomVector * _startingSpeed;
    }
}
