using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "PaddleSkin", menuName = "PaddleSkin")]
    public class PaddleSkin : ScriptableObject
    {
        [SerializeField] public List<Skin> paddleSkin;

        
    }
}