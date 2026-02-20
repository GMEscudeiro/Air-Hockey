using UnityEngine;
using System;

public class EnemyControls : MonoBehaviour
{
    public float speed = 10.0f;
    public float upperBound = 0.0f;
    public float lowerBound = 3.0f;
    public float boundX = 1.9f;
    public float cornerRadius = 1.24f;
    private Rigidbody2D rb2d;
    public Transform ballTransform;

    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 ballPos = ballTransform.position;
        var pos = transform.position;
        if(ballPos.y <= 0){
            ballPos.y = -ballPos.y;
        }

        Vector3 dir = ballPos - pos;
        dir.Normalize();

        Vector2 forceVec = dir * 2;
        var vel = rb2d.linearVelocity;
        vel.x = forceVec.x;
        vel.y = forceVec.y;

        rb2d.linearVelocity = vel;

        if (pos.y - 0.37f < upperBound) {                  
            pos.y = upperBound + 0.37f;
        }
        else if (pos.y + 0.37f > lowerBound) {
            pos.y = lowerBound - 0.37f;
        }
        if (pos.x + 0.37f > boundX){
            pos.x = boundX - 0.37f;
        }
        else if (pos.x - 0.37f < -boundX){
            pos.x = -boundX + 0.37f;
        }

        transform.position = pos;
    }
}
