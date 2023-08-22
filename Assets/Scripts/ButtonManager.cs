using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameSituation gameSituation;

    public void StartGame(bool aiSituation)
    {
        gameSituation.GetComponent<GameSituation>().SetAISituation(aiSituation);
        SceneManager.LoadScene("Game");
    }
    
    public void OnePlayer()
    {
        StartGame(true);
    }

    public void TwoPlayer()
    {
        
        StartGame(false);
    }

    public void LoadSkinScene()
    {
        SceneManager.LoadScene("Skin");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
