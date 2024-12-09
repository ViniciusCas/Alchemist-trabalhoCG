using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : IAttack
{
    // Start is called before the first frame update
    public int _damage { get; set; }
    public int _range { get; set; }
    public Position _AOE { get; set; }
    public FireSpell(int rank)
    {
        if(rank==1)
        {
            _damage = 4;
            _range = 4;
            _AOE = new Position(1, 1);
        }
        else if(rank==2)
        {
            _damage = 5;
            _range = 5;
            _AOE = new Position(1, 1);
        }   
        else if(rank==3)
        {
            _damage = 6;
            _range = 6;
            _AOE = new Position(1, 3);
        }
        else Debug.Log("Erro ao alocar FireSpell");
    }
}
