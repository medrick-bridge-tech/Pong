using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkinDisplayer : MonoBehaviour
{
    [SerializeField] private PaddleSkin _paddleSkin;
    [SerializeField] private GameObject skinCard;
    private List<Skin> _skins;
    private GameSituation _gameSituation;
    
    void Start()
    {
        _skins = _paddleSkin.paddleSkin;
        _gameSituation = FindObjectOfType<GameSituation>();
        DisplaySkins();
    }
    void DisplaySkins()
    {
        int counter = 1;
        foreach (var skin in _skins)
        {
            
            GameObject paddleSkin = Instantiate(skinCard, new Vector2((counter * 120f)+((counter-1)*100f), 200f),Quaternion.identity);
            paddleSkin.GetComponent<Button>().image.sprite = skin.sprite;
            
            paddleSkin.transform.SetParent(transform);
            paddleSkin.GetComponent<Button>().onClick.AddListener(() => _gameSituation.SetPaddleSkin(skin));
            counter++;
        }
    }

    private void Update()
    {
        Button[] skinCards = FindObjectsOfType<Button>();
        foreach (var card in skinCards)
        {
            Debug.Log(card.image.sprite.name);
            if (card.image.sprite == _gameSituation.GetPaddleSkin().sprite)
            {
                card.image.color = Color.red;
            }
            else
            {
                card.image.color = Color.white;
            }
        }
    }
}    


