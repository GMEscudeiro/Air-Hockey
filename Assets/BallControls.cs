using UnityEngine;
using System;

public class BallControl : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public AudioSource source;
    private float ballCornerCount = 0;
    private float ballCornerLimit = 1000;
    private Vector2[] corners = new Vector2[] {
        new Vector2(1.9f, 3.0f),   // Topo Direita
        new Vector2(-1.9f, 3.0f),  // Topo Esquerda
        new Vector2(1.9f, -3.0f),  // Baixo Direita
        new Vector2(-1.9f, -3.0f)  // Baixo Esquerda
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D coll){
        source.Play();
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = (rb2d.linearVelocity.x / 2) + (coll.collider.attachedRigidbody.linearVelocity.x / 3);
            vel.y = (rb2d.linearVelocity.y / 2) + (coll.collider.attachedRigidbody.linearVelocity.y / 3);
            rb2d.linearVelocity = vel;
        }
        if(coll.collider.CompareTag("Wall")){
            Vector2 vel;
            vel.x = (rb2d.linearVelocity.x / 1.3f);
            vel.y = (rb2d.linearVelocity.y / 1.3f);
            rb2d.linearVelocity = vel;
        }
    }

    void ResetBall(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame(){
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        bool isNearAnyCorner = false;

        foreach (Vector2 corner in corners)
        {
            if (Vector2.Distance(pos, corner) <= 0.6f)
            {
                isNearAnyCorner = true;
                break; 
            }
        }

        if (isNearAnyCorner)
        {
            ballCornerCount++;
        }

        if (ballCornerCount > ballCornerLimit)
        {
            ResetBall();
            ballCornerCount = 0;
        }
    }
}
