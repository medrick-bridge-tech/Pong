using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;


public enum GameStates
{
    ReadyToStart,
    End,
    Playing
}

public class GameManager : MonoBehaviour
{
    public GameStates GameState { get; set; }

    [SerializeField] private Ball _ball;
    [SerializeField] private GameObject obstacle;
    private float randomObstacleSize;
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private ScoreManager _scoreManager;
    private GameSituation _gameSituation;
    
    void Start()
    {
        GameState = GameStates.ReadyToStart;
        randomObstacleSize = Random.Range(1f, 3f);

        _gameSituation = FindObjectOfType<GameSituation>();
    }
    
    void Update()
    {
        if (GameState == GameStates.ReadyToStart && Input.GetKeyDown(KeyCode.Space))
        {
            _ball.UpdateRandomVector();
            _ball.StartMoving();
            GameState = GameStates.Playing;
            _gameSituation = FindObjectOfType<GameSituation>();
            if (_gameSituation.GetObstacleSituation())
            {
                GameObject newObstacle = Instantiate(obstacle, Vector3.zero, Quaternion.identity);
                newObstacle.transform.localScale = new Vector3(newObstacle.transform.localScale.x, randomObstacleSize,
                    newObstacle.transform.localScale.z);
            }
        }

        if (GameState != GameStates.Playing)
        {
            ResetPosition();
        }
    }

    public void EndGame()
    {
        GameState = GameStates.End;
        _winCanvas.SetActive(true);
        
        if (_scoreManager.playerScore > _scoreManager.aiScore)
        {
            _winText.text = "You win!";
        }
        else
        {
            if (_gameSituation.GetAISituation())
            {
                _winText.text = "You lose!";    
            }
            else
            {
                _winText.text = "Your friend win!";
            }
            
        }
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
    
    void ResetPosition()
    {
        Paddle paddle = FindObjectOfType<Paddle>();
        AI aiPaddle = FindObjectOfType<AI>();
        paddle.transform.position = new Vector3(paddle.transform.position.x, 0f, paddle.transform.position.y);
        aiPaddle.transform.position = new Vector3(aiPaddle.transform.position.x, 0f, aiPaddle.transform.position.y);
    }
}
