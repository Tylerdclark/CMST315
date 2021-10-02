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
    void FixedUpdate()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        var mat = meshRenderer.material;

        Vector2 offset = mat.mainTextureOffset;
        offset.x = player.transform.position.x / player.transform.localScale.x /parallax;
        offset.y = player.transform.position.y / player.transform.localScale.y /parallax;

        mat.mainTextureOffset = offset;
    }
}
