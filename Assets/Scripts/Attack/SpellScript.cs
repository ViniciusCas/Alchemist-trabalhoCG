using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour, IAttack
{
    public int damage { get; set; }
    public float speed { get; set; }
    public float lifespan { get; set; }

    void Start()
    {
        damage = 2;
        speed = 7.5f;
        lifespan = 2f; // Lifespan in seconds
    }

    void Update()
    {
        // Reduce lifespan over time
        if (lifespan > 0)
        {
            lifespan -= Time.deltaTime; // Decrease lifespan
            MoveForward(); // Move the Firespell forward
        }
        else
        {
            Destroy(gameObject); // Destroy the Firespell after lifespan ends
        }
    }

    // Function to handle forward movement
    void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
