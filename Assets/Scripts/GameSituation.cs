using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSituation : MonoBehaviour
{
    [SerializeField] private bool aiActive;
    
    public bool GetAISituation()
    {
        return aiActive;
    }

    public void SetAISituation(bool situation)
    {
        aiActive = situation;
    }
    // Start is called before the first frame update
    
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
