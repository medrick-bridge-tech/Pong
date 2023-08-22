using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameSituation : MonoBehaviour
{
    [Header("AI")]
    [SerializeField] private bool aiActive;
    [SerializeField][Range(1f,3f)] private float aiDifficulty = 1f;

    [Header("Skin")] [SerializeField] private Sprite skin;
    
    public bool GetAISituation()
    {
        return aiActive;
    }

    public void SetAISituation(bool situation)
    {
        aiActive = situation;
    }
    // Start is called before the first frame update
    public float GetAIDifficulty()
    {
        return aiDifficulty;
    }
    
    public void SetAIDifficulty(float difficulty)
    {
        aiDifficulty = difficulty;
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
