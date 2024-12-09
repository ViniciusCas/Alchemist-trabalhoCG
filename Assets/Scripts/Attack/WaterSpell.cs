using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpell : IAttack
{
    // Start is called before the first frame update
    public int _damage { get; set; }
    public int _range { get; set; }
    public Position _AOE { get; set; }
    public WaterSpell(int rank)
    {
        if(rank==1)
        {
            _damage = 3;
            _range = 3;
            _AOE = new Position(2, 2);
        }
        else if(rank==2)
        {
            _damage = 4;
            _range = 3;
            _AOE = new Position(3, 3);
        }   
        else if(rank==3)
        {
            _damage = 5;
            _range = 5;
            _AOE = new Position(4, 4);
        }
        else Debug.Log("Erro ao alocar WaterSpell");
    }
}
