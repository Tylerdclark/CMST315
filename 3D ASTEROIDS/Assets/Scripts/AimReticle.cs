using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimReticle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if(Physics.Raycast(ray, out hitData, 1000))
        {
            transform.position = hitData.point;
            if (hitData.rigidbody != null) //then it is an asteroid
            {
                
            }
        }
        
    }
}
