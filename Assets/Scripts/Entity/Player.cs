using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    public float rotationSpeed = 90f; // Degrees per second

    private Quaternion targetRotation;
    public GameObject FireSpell;
    private Animator animator;
    private int usingSpell=0;
    float moveX, moveZ;
    public float spellCooldown, lastUse = 0;
    public int _HP { get; set; }
    public float _MoveSpeed { get; set; }
    public List<IAttack> _Attacks { get; set; }
    void AnimationCheck()
    {
        if (Input.GetMouseButton(0))
        {
            animator?.SetTrigger("shoot");
        }
        else if (moveX != 0 || moveZ != 0)
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
    }
    void Start()
    {
        _HP = 10;
        _MoveSpeed = 5f;
        spellCooldown = 1f;
        _Attacks = new List<IAttack> {};
        animator = GetComponent<Animator>(); // Get the Animator component
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the Player object.");
        }
    }
    void SpellHandler()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) usingSpell=0;
        else if(Input.GetKeyDown(KeyCode.Alpha2)) usingSpell=1;
        else if(Input.GetKeyDown(KeyCode.Alpha3)) usingSpell=2;
    } 
    void SpellCast()
    {
        if (Input.GetMouseButton(0) && lastUse + spellCooldown < Time.time)
        {
            lastUse = Time.time;
            if(usingSpell==0)
            {
                Vector3 spawnPosition = transform.position + transform.forward;
                GameObject firespell = Instantiate(FireSpell, spawnPosition, transform.rotation, transform);
                firespell.transform.SetParent(null);
            }
            else if(usingSpell==1)
            {

            }
            else if(usingSpell==2)
            {

            }
        }
    }
    void Update()
    {

        PlayerMovement();
        AnimationCheck();
        SpellHandler();
        SpellCast();

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
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
