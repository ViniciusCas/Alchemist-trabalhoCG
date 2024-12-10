using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour, IEntity
{
    public int _HP { get; set; }
    public float _MoveSpeed { get; set; }
    public List<IAttack> _Attacks { get; set; }
    public Position _Position { get; set; }
    void Start()
    {
        _HP = 10;
        _MoveSpeed = 3;
        _Attacks = new List<IAttack> { new ClubMelee(1)};
        _Position = new Position(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
