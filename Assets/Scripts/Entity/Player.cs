using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    public float rotationSpeed = 90f; // Degrees per second

    private Quaternion targetRotation;
    public int _HP { get; set; }
    public float _MoveSpeed { get; set; }
    public List<IAttack> _Attacks { get; set; }
    public Position _Position { get; set; }

    void Start()
    {
        _HP = 10;
        _MoveSpeed = 5f;
        _Attacks = new List<IAttack> { new FireSpell(1), new ShockSpell(1), new WaterSpell(1)};
        _Position = new Position(0, 0);
        this.transform.Translate(3, 2, 0);
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        Vector3 worldMoveDirection = transform.TransformDirection(moveDirection);
        transform.Translate(worldMoveDirection * _MoveSpeed * Time.deltaTime, Space.World);

        if (Input.GetMouseButton(1)) // Update target point while Mouse2 is held down
        {
            // Perform a raycast to determine the target rotation
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 directionToTarget = hitInfo.point - transform.position;
                directionToTarget.y = 0; // Only change the Y coordinate
                targetRotation = Quaternion.LookRotation(directionToTarget);
            }
        }

        // Smoothly rotate towards the target rotation if it exists
        if (Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
