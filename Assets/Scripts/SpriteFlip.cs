using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Vector3 oldTransformPosition = Vector3.zero;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        oldTransformPosition = transform.position;
    }

    void Update()
    {

        if (transform.position.x < this.oldTransformPosition.x) spriteRenderer.flipX = true;
        else if (transform.position.x > this.oldTransformPosition.x) spriteRenderer.flipX = false;

       oldTransformPosition = transform.position;
    }
}
