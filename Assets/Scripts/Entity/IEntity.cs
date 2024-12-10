using System.Collections;
using System.Collections.Generic;
public struct Position
{
    public int coordX { get; set; }
    public int coordY { get; set; }

    public Position(int x, int y)
    {
        coordX = x;
        coordY = y;
    }
}
public interface IEntity {
    int _HP {get; set; }
    float _MoveSpeed {get; set; }
    List<IAttack> _Attacks { get; set; }
}
