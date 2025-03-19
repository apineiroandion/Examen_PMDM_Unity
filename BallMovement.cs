using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento
    private Rigidbody rb;

    public Transform cubo; // Referencia al objeto "Cubo"
    public float distanciaUmbral = 2f; // Distancia para considerar "cerca"

    public playerState state = playerState.sinDefinir;

    public enum playerState
    {
        cerca,
        lejos,
        sinDefinir
    }
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el Rigidbody
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float distancia = Vector3.Distance(transform.position, cubo.position);

        if (distancia <= distanciaUmbral)
        {
            state = playerState.cerca;
            Debug.Log("La bola está cerca del cubo.");
        }
        else
        {
            state = playerState.lejos;
            Debug.Log("La bola está lejos del cubo.");
        }

        /**
        float distancia = Vector3.Distance(transform.position, cubo.position);

        bool estaCerca = distancia <= distanciaUmbral;

        animator.SetBool("estaCerca", estaCerca); // Cambia el parámetro en el Animator

        Debug.Log(estaCerca ? "✅ La bola está cerca del cubo." : "❌ La bola está lejos del cubo.");
        **/
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ) * speed;
        rb.AddForce(movement, ForceMode.Acceleration);
    }
}
