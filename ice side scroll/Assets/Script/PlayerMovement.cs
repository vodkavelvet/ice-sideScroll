using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public float speed = 1f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput < 0) 
        {
            spriteRenderer.flipX = true;
        }  
        else 
        {
            spriteRenderer.flipX = false;
        }
    }

    void Start()
    {
        // Mengambil komponen Rigidbody2D dan SpriteRenderer
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // Menggerakkan player ke kanan atau kiri menggunakan transform.Translate
        float horizontalInput = Input.GetAxis("Horizontal");
        SpriteFlip(horizontalInput);

        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
    }

    void Update()
    {
        // Menangani lompatan
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
