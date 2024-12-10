using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridHandler 
{
    public class Grass : MonoBehaviour, ITile
    {
        private string description;
        private int movementCost;
        private IPower[] constrains;

        public string Name { get => name; set => name = value; }
        public IPower[] Constrains { get => constrains; set => constrains = value; }
        public Texture3D Texture { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int MovementCost { get => movementCost; set => movementCost = value; }
    }
}

