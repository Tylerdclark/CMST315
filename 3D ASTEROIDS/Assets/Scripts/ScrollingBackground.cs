using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public PlayerController player;
    public float parallax = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        var mat = meshRenderer.material;

        var offset = mat.mainTextureOffset;
        var transform1 = player.transform;
        var position = transform1.position;
        var localScale = transform1.localScale;
        
        offset.x = position.x / localScale.x /parallax;
        offset.y = position.y / localScale.y /parallax;

        mat.mainTextureOffset = offset;
    }
}
