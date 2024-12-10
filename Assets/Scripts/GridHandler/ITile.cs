using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridHandler
{
    public interface ITile
    {
        string Name { get; set; }
        int MovementCost { get; set; }
        IPower[] Constrains { get; set; }
        Texture3D Texture { get; set; }
    }
}
