using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStop : MonoBehaviour
{
    public Animator animator;
    public GameObject canvas;
    public GameObject barrier;
    bool run = false;
    bool ontrigger = false;

    private void Update()
    {
        if (run)
        {
            Quaternion barrierRotation = barrier.transform.rotation;
            Quaternion barrierNewRotation = Quaternion.Euler(barrier.transform.eulerAngles.x, -180, barrier.transform.eulerAngles.z);
            barrier.transform.rotation = Quaternion.Lerp(barrierRotation, barrierNewRotation, 0.05f);
            StartCoroutine(ExampleCoroutine());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!run && other.name == "Ch46_nonPBR")
        {
            canvas.SetActive(true);
            ontrigger = true;
        }
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        ontrigger = false;
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        animator.SetInteger("walking", 0);
    }
    public void Run()
    {

        if (ontrigger)
        {
            canvas.SetActive(false);
            run = true;
        }

    }
}
