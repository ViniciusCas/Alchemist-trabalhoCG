using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    public int _HP { get; set; }
    public int _MoveSpeed { get; set; }
    public List<IAttack> _Attacks { get; set; }
    public Position _Position { get; set; }
    public float moveSpeed = 5f;
    void Start()
    {
        _HP = 10;
        _MoveSpeed = 3;
        _Attacks = new List<IAttack> { new FireSpell(1), new ShockSpell(1), new WaterSpell(1)};
        _Position = new Position(0, 0);
        this.transform.Translate(3, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
