using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMinion : MonoBehaviour, IEntity
{
    public int _HP { get; set; }
    public float _MoveSpeed { get; set; }
    public int damageToPlayer = 1; // Amount of damage the skeleton inflicts on the player
    private Transform playerTransform;
    public string collidedObjectName;
    public float raycastMaxDistance = 10f;
    void Start()
    {
        _HP = 6;
        _MoveSpeed = 4f; // Adjust the speed as needed
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // Find the Player in the scene by tag
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else Debug.LogError("Player not found in the scene! Ensure the Player GameObject is tagged as 'Player'.");
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Move toward the Player
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.Translate(direction * _MoveSpeed * Time.deltaTime, Space.World);

            // Rotate to face the Player
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Smooth rotation
        }
        if(transform.position.y<=-10) Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Collision with FireSpell
        DetectObjectBelow();
        //Debug.Log("Detection");
        if (other.gameObject.CompareTag("C2H4"))
        {
            if(collidedObjectName=="Grass(Clone)") 
            {
                _HP-=6;
                PointsClass.playerScore += 10;
            }
            else _HP -=2;
            Debug.Log("C2H4");
        }
        else if (other.gameObject.CompareTag("Na"))
        {
            if(collidedObjectName=="Water(Clone)")
            {
                _HP-=6;
                PointsClass.playerScore += 10;
            }
            else _HP -=2;
            Debug.Log("Na");
        }
        else if (other.gameObject.CompareTag("F"))
        {
            if(collidedObjectName=="Sand(Clone)") 
            {
                _HP-=6;
                PointsClass.playerScore += 10;
            }
            else _HP -=2;
            Debug.Log("F");
        }
        else if (other.gameObject.CompareTag("NH4NO3"))
        {
            if(collidedObjectName=="Fire(Clone)")
            {
                _HP-=6;
                PointsClass.playerScore += 10;
            }
            else _HP -=2;
            Debug.Log("NH4NO3");
        }
        if (_HP <= 0)
        {
            Die(); // Call the Die method
        }
    }
    private void DetectObjectBelow()
    {
        Vector3 startPosition = transform.position; // Starting position for the raycast
        if (Physics.Raycast(startPosition, Vector3.down, out RaycastHit hit, raycastMaxDistance))
        {
            GameObject objectBelow = hit.collider.gameObject;
            collidedObjectName = objectBelow.name;
            //Debug.Log($"Object below SkeletonMinion is: {collidedObjectName}");
        }
        else
        {
            collidedObjectName = null; // No object below
            //Debug.Log("No object found below SkeletonMinion.");
        }
    }
    private void Die()
    {
        Debug.Log("SkeletonMinion has died!");
        PointsClass.playerScore += 10;
        Destroy(gameObject); // Destroy the skeleton GameObject
    }
}
