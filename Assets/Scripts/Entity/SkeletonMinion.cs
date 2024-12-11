using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMinion : MonoBehaviour, IEntity
{
    public int maxHealth = 6;
    public int _HP { get; set; }
    public float _MoveSpeed { get; set; }
    public int damageToPlayer = 1; // Amount of damage the skeleton inflicts on the player
    private Transform playerTransform;
    public string collidedObjectName;
    public float raycastMaxDistance = 10f;
    void Start()
    {
        _HP = maxHealth;
        _MoveSpeed = 3f; // Adjust the speed as needed
        
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
        DetectObjectBelow();
        //Debug.Log("Detection");
        if (other.gameObject.CompareTag("Na"))
        {
            if(collidedObjectName=="Agua(Clone)") 
            {
                _HP-=6;
                PointsClass.playerScore += 10;
            }
            else _HP -=2;
            Debug.Log("Na");
        }
        else if (other.gameObject.CompareTag("NH3"))
        {
            if(collidedObjectName=="Cloro(Clone)")
            {
                _HP-=6;
                PointsClass.playerScore += 10;
            }
            else _HP -=2;
            Debug.Log("NH3");
        }
        else if (other.gameObject.CompareTag("Fe2O3"))
        {
            if(collidedObjectName=="Aluminio(Clone)") 
            {
                _HP-=6;
                PointsClass.playerScore += 10;
            }
            else _HP -=2;
            Debug.Log("Fe2O3");
        }
        else if (other.gameObject.CompareTag("HCl"))
        {
            if(collidedObjectName=="Acido sufurico(Clone)")
            {
                _HP-=6;
                PointsClass.playerScore += 10;
            }
            else _HP -=2;
            Debug.Log("HCl");
        }
        if (_HP <= 0)
        {
            Die();
        }
    }
    private void DetectObjectBelow()
    {
        Vector3 startPosition = transform.position;
        if (Physics.Raycast(startPosition, Vector3.down, out RaycastHit hit, raycastMaxDistance))
        {
            GameObject objectBelow = hit.collider.gameObject;
            collidedObjectName = objectBelow.name;
        }
        else
        {
            collidedObjectName = null; 
        }
    }
    private void Die()
    {
        Debug.Log("SkeletonMinion has died!");
        PointsClass.playerScore += 10;
        Destroy(gameObject);
    }
}
