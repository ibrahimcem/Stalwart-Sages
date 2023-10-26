using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryButton : MonoBehaviour
{
    public GameObject Door;
    public float openAngle;
    public bool isOpen = false;
    Quaternion startRot;
    public GameObject board;
    public GameObject number;
    int x;
    void Start()
    {
        startRot = Door.transform.rotation;
        x = Random.RandomRange(10, 99);
    }
    private void OnMouseDown()
    {
        if (!isOpen)
        {
            board.SetActive(true);
        }
        
    }
    public void open()
    {
        isOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion currentRot = Door.transform.rotation;
        Quaternion newRot = Quaternion.Euler(Door.transform.eulerAngles.x, openAngle, Door.transform.eulerAngles.z);

        if (isOpen)
        {
            Door.transform.rotation = Quaternion.Lerp(currentRot, newRot, 0.01f);
            StartCoroutine(ExampleCoroutine());
        }
        else
        {
            Door.transform.rotation = Quaternion.Lerp(currentRot, startRot, 0.01f);
        }
    }
    IEnumerator ExampleCoroutine()
    {
        number.transform.GetComponent<Text>().text = x.ToString();
        number.SetActive(true);
        yield return new WaitForSeconds(1);
        board.SetActive(false);
        number.SetActive(false);

    }
}
