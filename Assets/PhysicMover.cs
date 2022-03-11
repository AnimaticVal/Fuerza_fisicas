using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMath;


public class FluidResistedMover : MonoBehaviour
{
    Vector3 displacement, diferencia;
    [SerializeField] Vector3 velocity, acceleration, damping, weight;
    [SerializeField] float Xborde, Yborde;
    [SerializeField] public float masa;
    

    [SerializeField]Transform referencia;
    GravitacionalAtraction masaReferencia;

    // Start is called before the first frame update
    void Start()
    {
        referencia = GetComponent<Transform>();
        masaReferencia = referencia.GetComponent<GravitacionalAtraction>();
    }

    // Update is called once per frame
    void Update()
    {
       
       
       // ApplyForce(new Vector3(1, 0, 0));

         Move();
        CheckCollisions();
        acceleration = Vector3.zero;
    }
    public void Move()
    {
        velocity = velocity + acceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position = transform.position + new Vector3(displacement.x, displacement.y, 0);

        acceleration.Draw(transform.position, Color.blue);
        velocity.Draw(transform.position, Color.green);
        transform.position.Draw(Color.red);
    }

    private void CheckCollisions()
    {
        if (transform.position.x >= Xborde || transform.position.x <= -Xborde)
        {

            if (transform.position.x >= Xborde) transform.position = new Vector3(Xborde, transform.position.y, 0);
            else if (transform.position.y <= -Xborde) transform.position = new Vector3(-Xborde, transform.position.y, 0);
            velocity.x = velocity.x * -1;
            velocity.x = velocity.x * damping.x;
        }

        if (transform.position.y >= Yborde || transform.position.y <= -Yborde)
        {
            if (transform.position.y >= Yborde) transform.position = new Vector3(transform.position.x, Yborde, 0);
            else if (transform.position.y <= -Yborde) transform.position = new Vector3(transform.position.x, -Yborde, 0);
            velocity.y = velocity.y * -1;
            velocity.y = velocity.y * damping.y;

        }
    }

    private void ApplyForce(Vector3 force) {

        acceleration += force / masa;
    }


}
