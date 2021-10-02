using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour
{
    public GameObject reticle;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.DrawRay(transform.position, (reticle.gameObject.transform.position - transform.position), Color.green);
    }
}
