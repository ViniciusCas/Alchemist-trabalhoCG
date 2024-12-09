using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubMelee : IAttack
{
    // Start is called before the first frame update
    public int _damage { get; set; }
    public int _range { get; set; }
    public Position _AOE { get; set; }
    public ClubMelee(int rank)
    {
        if(rank==1)
        {
            _damage = 1;
            _range = 1;
            _AOE = new Position(1, 1);
        }
        else if(rank==2)
        {
            _damage = 2;
            _range = 1;
            _AOE = new Position(1, 1);
        }   
        else if(rank==3)
        {
            _damage = 3;
            _range = 1;
            _AOE = new Position(1, 1);
        }
        else Debug.Log("Erro ao alocar ClubMelee");
    }
}
