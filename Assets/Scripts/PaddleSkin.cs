using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



    [CreateAssetMenu(fileName = "PaddleSkin", menuName = "PaddleSkin")]
    public class PaddleSkin : ScriptableObject
    {
        [SerializeField] public List<Skin> paddleSkin;

        
    }
