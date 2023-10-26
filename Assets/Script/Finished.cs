using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finished : MonoBehaviour
{
    public GameObject canvas;
    public GameObject text;
    public GameObject character;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds((float)0.6);
        Animator animator = canvas.gameObject.GetComponent<Animator>();
        animator.SetInteger("start", 1);
        yield return new WaitForSeconds(2);
        text.SetActive(true);
        yield return new WaitForSeconds((float)0.8);
        SceneManager.LoadScene(0);
    }
}
