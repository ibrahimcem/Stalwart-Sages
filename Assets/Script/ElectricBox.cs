using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBox : MonoBehaviour
{
    public GameObject canvas;
    public Camera camera;
    public GameObject stairs1;
    public GameObject stairs2;
    public GameObject barrier1;
    public GameObject barrier2;
    public bool completed = false;

    private void OnMouseDown()
    {
        if (!completed)
        {
            canvas.SetActive(true);
            camera.GetComponent<AudioListener>().enabled = false;
            camera.GetComponent<AudioSource>().enabled = false;
        }
    }

    private void Update()
    {
        if (completed)
        {
            camera.GetComponent<AudioListener>().enabled = true;
            camera.GetComponent<AudioSource>().enabled = true;

        }
    }
}