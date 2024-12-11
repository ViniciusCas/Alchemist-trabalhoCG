using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridHandler
{
    public interface ITile
    {
        string Name { get; set; }
        int MovementCost { get; set; }
        Texture3D Texture { get; set; }
    }
}
