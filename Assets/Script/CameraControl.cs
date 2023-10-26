using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform hedef;
    public Vector3 hedefMesafe;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + hedefMesafe, Time.deltaTime * 10);
    }
}
