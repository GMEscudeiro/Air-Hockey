using UnityEngine;

public class BallControl : MonoBehaviour
{

    private Rigidbody2D rb2d;

    void GoBall(){
        var pos = transform.position;
        pos.y = 0.0f;
        pos.y = 0.0f;
        transform.position = pos;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
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
        Invoke("GoBall", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
