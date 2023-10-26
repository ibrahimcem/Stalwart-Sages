using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareScript : MonoBehaviour
{
    public GameObject jumpScare;
    public GameObject mainCamera;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        mainCamera.SetActive(false);
        jumpScare.SetActive(true);
        yield return new WaitForSeconds((float)2.3);
        jumpScare.SetActive(false);
        mainCamera.SetActive(true);
        
    }
}
