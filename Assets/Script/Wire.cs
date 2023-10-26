using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    Vector3 startPoint;
    public Camera mainCamera;
    public GameObject wire;
    Vector3 startPoint2;
    public GameObject faz;
    public GameObject nötr;
    public GameObject empty;
    public GameObject switch2;
    public TextMesh text;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.localPosition;
        
    }
    // Update is called once per frame
    private void OnMouseDrag()
    {
        if(text.text == 0.ToString())
        {
            transform.GetComponent<TextMesh>().text = 0.ToString();
            startPoint2 = startPoint;
            Vector2 position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(position);
            newPosition.z = 0;
            Collider[] colliders = Physics.OverlapBox(newPosition, new Vector3(0, 0, 15501));
            foreach (Collider collider in colliders)
            {

                if (collider.gameObject != gameObject)
                {
                    string tamam = "Tube120";
                    if (collider.gameObject.transform.name != tamam)
                    {
                        UpdateWire(collider.transform.localPosition);
                        startPoint2 = collider.transform.localPosition;
                        if (collider.gameObject.transform.name == transform.name)
                        {
                            transform.GetComponent<TextMesh>().text = 1.ToString();
                        }
                        if (transform.name == "Ground")
                        {
                            transform.GetComponent<TextMesh>().text = 1.ToString();
                        }
                        return;
                    }

                }
            }

            UpdateWire(newPosition);
        }
        else
        {
            mainCamera.transform.GetComponent<AudioSource>().mute = false;
        }
        

    }
    private void OnMouseUp()
    {
        if (text.text == 0.ToString())
        {
            UpdateWire(startPoint2);
        }
            
    }
    void UpdateWire(Vector3 newPosition)
    {
        
        transform.localPosition = newPosition;
        Vector3 direction = newPosition - startPoint;
        transform.right = -direction * transform.lossyScale.x;
        float dist = Vector2.Distance(newPosition, startPoint);
        wire.transform.localScale = new Vector3(1, 1, -dist / 44);
    }
}
