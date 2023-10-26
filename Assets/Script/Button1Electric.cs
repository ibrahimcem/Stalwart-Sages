using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1Electric : MonoBehaviour
{
    public GameObject electricBox;
    public GameObject stairs;
    public GameObject barrier;
    public GameObject canvas;
    bool run = false;

    private void Update()
    {
        
        if (run)
        {
            Vector3 stairsPosition = stairs.transform.position;
            Vector3 stairsNewPosition = new Vector3(-13, stairs.transform.position.y, 24);
            Quaternion barrierRotation = barrier.transform.rotation;
            Quaternion barrierNewRotation = Quaternion.Euler(barrier.transform.eulerAngles.x, 0, barrier.transform.eulerAngles.z);
            stairs.transform.position = Vector3.Lerp(stairsPosition, stairsNewPosition, 0.05f);
            barrier.transform.rotation = Quaternion.Lerp(barrierRotation, barrierNewRotation, 0.01f);
        }
    }
    private void OnMouseDown()
    {
        
        if (electricBox.gameObject.GetComponent<ElectricBox>().completed)
        {
            run = true;
        }
        else
        {
            StartCoroutine(ExampleCoroutine());
        }
    }
    IEnumerator ExampleCoroutine()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(1);
        canvas.SetActive(false);
    }
}
