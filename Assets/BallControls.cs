using UnityEngine;

public class BallControl : MonoBehaviour
{

    private Rigidbody2D rb2d;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = rb2d.linearVelocity.x;
            vel.y = (rb2d.linearVelocity.y / 2) + (coll.collider.attachedRigidbody.linearVelocity.y / 3);
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
        
    }
}
