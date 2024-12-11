using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IEntity
{
    public float rotationSpeed = 270f; // Degrees per second

    private Quaternion targetRotation;
    
    private GameObject Na;
    private GameObject NH3;
    private GameObject Fe2O3;
    private GameObject HCl;

    public HealthBar healthBar;
    public CooldownBar cooldownBar;

    public AudioClip shootSoundClip;
    private AudioSource audioSource;

    private Animator animator;
    public static int usingSpell=0;
    float moveX, moveZ;
    public float spellCooldown, lastUse = 0;

    public int maxHealth = 100;
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
        _HP = maxHealth;
        healthBar.SetMaxHealth(this.maxHealth);

        spellCooldown = 1f;
        cooldownBar.SetMaxCooldown(this.spellCooldown);

        _MoveSpeed = 5f;

        animator = GetComponent<Animator>(); 
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the Player object.");
        }

        audioSource = GetComponent<AudioSource>();

        Na = GameObject.Find("Na");
        NH3 = GameObject.Find("NH3");
        Fe2O3 = GameObject.Find("Fe2O3");
        HCl = GameObject.Find("HCl");
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
            if(usingSpell==0) //Na -> H2O
            {
                Vector3 spawnPosition = transform.position + transform.forward;
                GameObject C2H4Reaction = Instantiate(Na, spawnPosition, transform.rotation, transform);
                C2H4Reaction.AddComponent<SpellScript>();
                C2H4Reaction.transform.SetParent(null);
            }
            else if(usingSpell==1) // NH3 -> Cl
            {
                Vector3 spawnPosition = transform.position + transform.forward;
                GameObject NaReaction = Instantiate(NH3, spawnPosition, transform.rotation, transform);
                NaReaction.AddComponent<SpellScript>();
                NaReaction.transform.SetParent(null);
            }
            else if(usingSpell==2) //Fe2O3 -> Al
            {
                Vector3 spawnPosition = transform.position + transform.forward;
                GameObject FReaction = Instantiate(Fe2O3, spawnPosition, transform.rotation, transform);
                FReaction.AddComponent<SpellScript>();
                FReaction.transform.SetParent(null);
            }
            else if(usingSpell==3) //HCl -> FeS
            {
                Vector3 spawnPosition = transform.position + transform.forward;
                GameObject NH4NO3Reaction = Instantiate(HCl, spawnPosition, transform.rotation, transform);
                NH4NO3Reaction.AddComponent<SpellScript>();
                NH4NO3Reaction.transform.SetParent(null);
            }

            audioSource.clip = shootSoundClip;
            audioSource.Play();
        }
    }
    void Update()
    {

        PlayerMovement();
        AnimationCheck();
        SpellHandler();
        SpellCast();
        UpdateCooldown();

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

    void UpdateCooldown()
    {
        if (lastUse + spellCooldown > Time.time)
        {
            cooldownBar.SetCooldown(Time.time - lastUse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(_HP);
        if (collision.gameObject.CompareTag("Enemy"))
        {
           TakeDamage();
        }
    }

    void TakeDamage()
    {
        this._HP -= 20;
        healthBar.SetHealth(this._HP);


        if (this._HP <= 0)
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
