using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10.0f;
    public float upperBound = 0.0f;
    public float lowerBound = -3.0f;
    public float boundX = 1.5f;
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;           // Acessa a Posição da raquete
        Vector3 dir = mousePos - pos;
        dir.Normalize();

        Vector2 forceVec = dir * 10;
        var vel = rb2d.linearVelocity;                // Acessa a velocidade da raquete
        vel.x = forceVec.x;
        vel.y = forceVec.y;

        rb2d.linearVelocity = vel;                    // Atualizada a velocidade da raquete

        if (pos.y + 0.5f > upperBound) {                  
            pos.y = upperBound - 0.5f;
        }
        else if (pos.y - 0.55f < -3.0f) {
            pos.y = -3.0f;
        }
        if (pos.x > 1.5f){
            pos.x = 1.5f;
        }
        else if (pos.x < -1.5f){
            pos.x = -1.5f;
        }
        transform.position = pos;               // Atualiza a posição da raquete
    }
}
