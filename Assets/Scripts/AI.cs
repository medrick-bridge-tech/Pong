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
    private GameSituation gameSituation;
    
    [SerializeField] private bool isAiActive;

    private float aiDifficulty;
    private void Start()
    {
        gameSituation = FindObjectOfType<GameSituation>();
        isAiActive = gameSituation.GetComponent<GameSituation>().GetAISituation();
        aiDifficulty = gameSituation.GetComponent<GameSituation>().GetAIDifficulty();
        if (isAiActive)
        {
            _verticalSpeed = _verticalSpeed * aiDifficulty;
            
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
            var verticalMovement = Input.GetAxis("Vertical2") * _verticalSpeed * Time.deltaTime;
        
            transform.position = new Vector3(transform.position.x, 
                Mathf.Clamp(transform.position.y + verticalMovement, MIN_Y_POS, MAX_Y_POS), transform.position.z);
        }
    }
}
