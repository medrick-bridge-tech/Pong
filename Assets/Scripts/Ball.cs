using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _startingSpeed;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject ballVFX;
    
    private float _randomX;
    private float _randomY;
    private Vector2 _randomVector;
    private Rigidbody2D _ballRigidbody;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ParticleChangeColor(Color.blue);
        }else if (other.gameObject.CompareTag("Enemy"))
        {
            ParticleChangeColor(Color.red);
        }
    }

    void ParticleChangeColor(Color color)
    {
        ballVFX.GetComponent<ParticleSystem>().startColor = color;
    }

    void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody2D>();
        ballVFX.SetActive(false);
    }

    private void Update()
    {
        FlipParticle();
    }

    private void FlipParticle()
    {
        if (_ballRigidbody.velocity.x > 0f)
        {
            ballVFX.transform.localScale =
                new Vector3(ballVFX.transform.localScale.x, ballVFX.transform.localScale.y, -0.5f);
        }
        else
        {
            ballVFX.transform.localScale = new Vector3(ballVFX.transform.localScale.x , ballVFX.transform.localScale.y , 0.5f);
        }
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
        _randomX = Random.Range(-10f, 10f);
        _randomY = Random.Range(-0.1f, 0.1f);
        _randomVector = new Vector2(_randomX, _randomY).normalized;
    }

    public void StartMoving()
    {
        _gameManager.GameState = GameStates.Playing;
        _ballRigidbody.velocity = _randomVector * _startingSpeed;
        ballVFX.SetActive(true);
    }
}
