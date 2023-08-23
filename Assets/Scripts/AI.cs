using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AI : MonoBehaviour
{
    private const float MIN_Y_POS = -3.93f;
    private const float MAX_Y_POS = 3.93f;
    
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private Ball _ball;
    
    [SerializeField] private GameManager _gameManager;
    private GameSituation _gameSituation;
    
    [SerializeField] private bool isAiActive;

    private float aiDifficulty;
    private Sprite _sprite;
    
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _gameSituation = FindObjectOfType<GameSituation>();
        isAiActive = _gameSituation.GetAISituation();
        Debug.Log(isAiActive);
        aiDifficulty = _gameSituation.GetAIDifficulty();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        if (isAiActive)
        {
            _verticalSpeed = _verticalSpeed * aiDifficulty;
        }
        else
        {
            _verticalSpeed = _gameSituation.GetPaddleSkin().speed;
            _spriteRenderer.sprite = _gameSituation.GetPaddleSkin().sprite;
        }
        
        
    }
    private void Update()
    {
        if (isAiActive)
        {
            KeepTrackOfBall();    
        }
        else
        {
            VerticalMove();
        }
    }

    

    private void KeepTrackOfBall()
    {
        var targetY = _ball.transform.position.y;
        targetY = Mathf.Clamp(targetY, MIN_Y_POS, MAX_Y_POS);
        var step = _verticalSpeed * Time.deltaTime;
        var targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
    
    private void VerticalMove()
    {
        if (_gameManager.GameState == GameStates.Playing)
        {
            var verticalMovement = Input.GetAxis("Vertical1") * _verticalSpeed * Time.deltaTime;
        
            transform.position = new Vector3(transform.position.x, 
                Mathf.Clamp(transform.position.y + verticalMovement, MIN_Y_POS, MAX_Y_POS), transform.position.z);
        }
    }
}
