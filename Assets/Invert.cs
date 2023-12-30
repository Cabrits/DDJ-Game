using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite(horizontalInput);
    }

    void FlipSprite(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; 
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; 
        }
    }
}

