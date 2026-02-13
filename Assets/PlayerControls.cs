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

        // if (pos.y > upperBound) {                  
        //     pos.y = upperBound;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        // }
        // else if (pos.y < -lowerBound) {
        //     pos.y = -lowerBound;                    // Corrige a posicao da raquete caso ele ultrapasse o limite inferior
        // }
        // if (pos.x > boundX){
        //     pos.x = boundX;
        // }
        // else if (pos.x < -boundX){
        //     pos.x = -boundX;
        // }
        // transform.position = pos;               // Atualiza a posição da raquete
    }
}
