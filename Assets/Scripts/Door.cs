using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Mage") return;
        animator.SetBool("isOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name != "Mage") return;
        animator.SetBool("isOpen", false);
    }
}
