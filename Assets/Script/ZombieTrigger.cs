using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    public GameObject character;
    bool run = false;
    bool run2 = false;
    public GameObject timer;
    private void Update()
    {
        if (run && !run2)
        {
            StartCoroutine(ExampleCoroutine());
            run2 = true;
            
        }
        run = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Ch46_nonPBR")
        {
            run = true;

        }
    }

    IEnumerator ExampleCoroutine()
    {
        character.transform.GetComponent<CharacterControllers>().speed = character.transform.GetComponent<CharacterControllers>().speed / 2;
        timer.SetActive(true);
        yield return new WaitForSeconds(10);
        timer.SetActive(false);
        character.transform.GetComponent<CharacterControllers>().speed = character.transform.GetComponent<CharacterControllers>().speed * 2;

    }
}
