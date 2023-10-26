using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWalking : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        animator.SetInteger("walking", 1);
    }
}
