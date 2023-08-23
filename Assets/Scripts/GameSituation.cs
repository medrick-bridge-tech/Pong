using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameSituation : MonoBehaviour
{
    [Header("AI")]
    [SerializeField] private bool isAIA0ctive;
    [SerializeField][Range(1f,3f)] private float aiDifficulty = 1f;
    
    [Header("Skin")] [SerializeField] private Sprite skin;

    [SerializeField] private bool obstacleActive;
    
    //AI
    public bool GetAISituation()
    {
        return isAIA0ctive;
    }

    public void SetAISituation(bool situation)
    {
        isAIA0ctive = situation;
    }
    
    public float GetAIDifficulty()
    {
        return aiDifficulty;
    }
    
    public void SetAIDifficulty(float difficulty)
    {
        aiDifficulty = difficulty;
    }

    //Obstacle

    public bool GetObstacleSituation()
    {
        return obstacleActive;
    }

    public void SetObstacleSituation(bool situation)
    {
        obstacleActive = situation;
    }
    void Start()
    {
        
    }

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSituation>().Length;
        if(gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
