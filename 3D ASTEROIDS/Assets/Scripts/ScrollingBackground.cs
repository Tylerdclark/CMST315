using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        var mat = meshRenderer.material;

        Vector2 offset = mat.mainTextureOffset;
        offset.x += Time.deltaTime / 10f;

        mat.mainTextureOffset = offset;
    }
}
