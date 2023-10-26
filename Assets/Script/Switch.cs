using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    Quaternion quaternion;
    public TextMesh text;
    public TextMesh faz;
    public TextMesh nötr;
    public TextMesh empty;
    public GameObject canvas;
    public GameObject electricBox;
    public GameObject number;
    public GameObject mainCamera;
    int x;
    // Start is called before the first frame update
    void Start()
    {
        quaternion = transform.localRotation;
        x = Random.Range(0, 9);
    }

    // Update is called once per frame
    public void SwitchOn()
    {
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        if (text.text == 1.ToString())
        {
            mainCamera.transform.GetComponent<AudioSource>().mute = true;
            text.text = 0.ToString();
            quaternion.z = 0;
            transform.localRotation = quaternion;
        }
        else
        {
            text.text = 1.ToString();
            quaternion.z = 180;
            transform.localRotation = quaternion;
            yield return new WaitForSeconds((float)0.3);
            if (faz.text ==1.ToString() && nötr.text == 1.ToString() && empty.text == 0.ToString())
            {
                text.text = 2.ToString();
                quaternion.z = 180;
                transform.localRotation = quaternion;
                number.GetComponent<Text>().text = x.ToString();
                number.SetActive(true);
                yield return new WaitForSeconds(1);
                canvas.SetActive(false);
                number.SetActive(false);
                electricBox.transform.GetComponent<ElectricBox>().completed = true;
                



            }
            else
            {
                text.text = 0.ToString();
                quaternion.z = 0;
                transform.localRotation = quaternion;

            }
        }

    }
}
