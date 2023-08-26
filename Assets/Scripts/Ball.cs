using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    
    [SerializeField] private float _startingSpeed;
    [SerializeField] private GameManager _gameManager;
    
    [SerializeField] private AudioClip ballHitAudio;
    private float _randomX;
    private float _randomY;
    private Vector2 _randomVector;
    private Rigidbody2D _ballRigidbody;

    private AudioSource _audioSource;
     
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        
        _audioSource.PlayOneShot(ballHitAudio);
    }

    

    void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        
    }

    

    
    public void ResetPosition()
    {
        transform.position = Vector3.zero;
    }

    public void StopMoving()
    {
        _ballRigidbody.velocity = Vector2.zero;
        gameObject.GetComponent<TrailRenderer>().emitting = false;
        
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
        gameObject.GetComponent<TrailRenderer>().emitting = true;
       
    }
}
