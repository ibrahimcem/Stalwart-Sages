using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTaskButton : MonoBehaviour
{
    public GameObject canvas;
    public bool comleted = false;
    private void OnMouseDown()
    {
        if (!comleted)
        {
            canvas.SetActive(true);
        }
        

    }
}
