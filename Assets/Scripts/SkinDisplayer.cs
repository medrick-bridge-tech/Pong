using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
namespace DefaultNamespace
{
    public class SkinDisplayer : MonoBehaviour
    {
        [SerializeField] private PaddleSkin _paddleSkin;
        [SerializeField] private GameObject skinCard;
        private List<Skin> _skins;
        void Start()
        {
            _skins = _paddleSkin.paddleSkin;
            DisplaySkins();
        }

        void DisplaySkins()
        {
            int counter = 1;
            foreach (var skin in _skins)
            {
                GameObject paddleSkin = Instantiate(skinCard, new Vector2((counter * 120f)+((counter-1)*100f), 200f),Quaternion.identity);
                paddleSkin.GetComponent<Button>().image.overrideSprite = skin.sprite;
                paddleSkin.transform.SetParent(transform);
                
                counter++;
            }
        }
    }    
}

