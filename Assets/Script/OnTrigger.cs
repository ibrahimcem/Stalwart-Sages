using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        material.EnableKeyword("_EMISSION");
    }
    private void OnTriggerExit(Collider other)
    {
        material.DisableKeyword("_EMISSION");
    }
}
