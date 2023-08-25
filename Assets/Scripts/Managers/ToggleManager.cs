using UnityEngine;
using System;
using UnityEngine.UI;
namespace DefaultNamespace
{
    public class ToggleManager : MonoBehaviour
    {
        [SerializeField] Toggle obstacleToggle;
        
        private GameSituation _gameSituation;


        public void CheckObstacleToggle()
        {
            
            
            bool obstacleActive = obstacleToggle.isOn;
            _gameSituation.SetObstacleSituation(obstacleActive);
        }


        void Start()
        {
            _gameSituation = FindObjectOfType<GameSituation>();
            
            
            obstacleToggle.isOn = _gameSituation.GetObstacleSituation();
        }
    }
}