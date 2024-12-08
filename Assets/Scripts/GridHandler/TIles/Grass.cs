using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridHandler 
{
    public class Grass : MonoBehaviour, ITile
    {
        private string description;
        private int speedModifier;
        private IPower[] constrains;

        public string Name { get => name; set => name = value; }
        public IPower[] Constrains { get => constrains; set => constrains = value; }
        public Texture3D Texture { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int SpeedModifier { get => speedModifier; set => speedModifier = value; }
    }
}

