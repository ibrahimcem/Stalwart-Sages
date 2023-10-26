using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCanvas : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        StartCoroutine(ExampleCoroutine());

    }
    IEnumerator ExampleCoroutine()
    {
        animator.SetInteger("start", 1);
        yield return new WaitForSeconds(1);
        transform.gameObject.SetActive(false);
    }

}
