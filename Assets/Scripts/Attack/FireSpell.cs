using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firespell : MonoBehaviour, IAttack
{
    public int damage { get; set; }
    public float speed { get; set; }
    public float lifespan { get; set; }

    void Start()
    {
        damage = 2;
        speed = 5.5f;
        lifespan = 3f; // Lifespan in seconds
    }

    void Update()
    {
        // Reduce lifespan over time
        if (lifespan > 0)
        {
            lifespan -= Time.deltaTime; // Use Time.deltaTime for accurate timing
        }
        else
        {
            Destroy(gameObject); // Destroy the Firespell after lifespan ends
        }

        // Move the Firespell forward in its local space
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
}
