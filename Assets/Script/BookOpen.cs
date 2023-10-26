using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpen : MonoBehaviour
{
    public GameObject book;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        book.SetActive(true);
    }
    public void BookClosed()
    {
        book.SetActive(false);
    }
}
