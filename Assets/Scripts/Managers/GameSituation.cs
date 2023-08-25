using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class GameSituation : MonoBehaviour
{
    [Header("AI")]
    [SerializeField] private bool isAIActive;
    [SerializeField][Range(1f,3f)] private float aiDifficulty = 1f;

    [Header("Skin")]
    [SerializeField] private Skin paddleSkin;
    [Header("Obstacle")] 
    [SerializeField] private bool obstacleActive;
    
    //AI
    public bool GetAISituation()
    {
        return isAIActive;
    }

    public void SetAISituation(bool situation)
    {
        isAIActive = situation;
    }
    
    public float GetAIDifficulty()
    {
        return aiDifficulty;
    }
    
    public void SetAIDifficulty(float difficulty)
    {
        aiDifficulty = difficulty;
    }
    
    //Skin
    public Skin GetPaddleSkin()
    {
        return paddleSkin;
    }

    public void SetPaddleSkin(Skin skin)
    {
        paddleSkin = skin;
        
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
