using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IEntity
{
    public float rotationSpeed = 180f; // Degrees per second

    private Quaternion targetRotation;
    public GameObject fireSpellPrefab;
    public GameObject C2H4;
    public GameObject Na;
    public GameObject F;
    public GameObject NH4NO3;
    private Animator animator;
    public static int usingSpell=0;
    float moveX, moveZ;
    public float spellCooldown, lastUse = 0;
    public int _HP { get; set; }
    public float _MoveSpeed { get; set; }
    void AnimationCheck()
    {
        if (moveX != 0 || moveZ != 0)
        {
            animator?.SetTrigger("walk"); // Trigger the "walk" animation
        }
        else
        {
            animator?.SetTrigger("stop");
        }
    }
    void PlayerMovement()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        transform.Translate(moveDirection * _MoveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.Q)) transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E)) transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
    void Start()
    {
        _HP = 3;
        _MoveSpeed = 5f;
        spellCooldown = 1f;
        animator = GetComponent<Animator>(); // Get the Animator component
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the Player object.");
        }
        fireSpellPrefab = GameObject.Find("fireSpellPrefab");
        C2H4 = GameObject.Find("C2H4");
        Na = GameObject.Find("Na");
        F = GameObject.Find("F");
        NH4NO3 = GameObject.Find("NH4NO3");
    }
    void SpellHandler()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) usingSpell=0;
        else if(Input.GetKeyDown(KeyCode.Alpha2)) usingSpell=1;
        else if(Input.GetKeyDown(KeyCode.Alpha3)) usingSpell=2;
        else if(Input.GetKeyDown(KeyCode.Alpha4)) usingSpell=3;
    } 
    void SpellCast()
    {
        if (Input.GetMouseButton(0) && lastUse + spellCooldown < Time.time)
        {
            animator?.SetTrigger("shoot");
            lastUse = Time.time;
            if(usingSpell==0) //Etileno -> Grama
            {
                Vector3 spawnPosition = transform.position + transform.forward;
                GameObject C2H4Reaction = Instantiate(C2H4, spawnPosition, transform.rotation, transform);
                C2H4Reaction.AddComponent<SpellScript>();
                C2H4Reaction.transform.SetParent(null);
            }
            else if(usingSpell==1) //Sódio Metálico -> Água
            {
                Vector3 spawnPosition = transform.position + transform.forward;
                GameObject NaReaction = Instantiate(Na, spawnPosition, transform.rotation, transform);
                NaReaction.AddComponent<SpellScript>();
                NaReaction.transform.SetParent(null);
            }
            else if(usingSpell==2) //Flúor ->Areia
            {
                Vector3 spawnPosition = transform.position + transform.forward;
                GameObject FReaction = Instantiate(F, spawnPosition, transform.rotation, transform);
                FReaction.AddComponent<SpellScript>();
                FReaction.transform.SetParent(null);
            }
            else if(usingSpell==3) //Nitrato de Amônio -> Fogo
            {
                Vector3 spawnPosition = transform.position + transform.forward;
                GameObject NH4NO3Reaction = Instantiate(NH4NO3, spawnPosition, transform.rotation, transform);
                NH4NO3Reaction.AddComponent<SpellScript>();
                NH4NO3Reaction.transform.SetParent(null);
            }
        }
    }
    void Update()
    {

        PlayerMovement();
        AnimationCheck();
        SpellHandler();
        SpellCast();

        /*if (Input.GetMouseButton(1)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 directionToTarget = hitInfo.point - transform.position;
                directionToTarget.y = 0; // Only change the Y coordinate
                Debug.Log(directionToTarget);
                targetRotation = Quaternion.LookRotation(directionToTarget);
                Debug.Log(targetRotation);
            }
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }*/
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(_HP);
        if (collision.gameObject.CompareTag("Enemy"))
        {
           this._HP-=1;
        }
        if(this._HP<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
