using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject canvas;
    public Animator animator;
    public void PlayButton()
    {
        StartCoroutine(ExampleCoroutine());
        
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    IEnumerator ExampleCoroutine()
    {
        canvas.SetActive(true);
        animator.SetInteger("start", 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
