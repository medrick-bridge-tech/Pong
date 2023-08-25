using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int playerScore;
    public int aiScore;
    
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _aiScoreText;


    public void UpdateScoreboard()
    {
        _playerScoreText.text = playerScore.ToString();
        _aiScoreText.text = aiScore.ToString();    
    }
}
