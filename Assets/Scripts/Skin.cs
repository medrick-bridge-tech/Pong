using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Build.Content;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Serialization;


namespace DefaultNamespace
{
    [Serializable]
    public class Skin
    {
        public Sprite sprite;
        public int price;
        public float speed;

    }
}