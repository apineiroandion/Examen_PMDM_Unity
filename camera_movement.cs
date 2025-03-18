using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public Transform target; // La bola
    public Vector3 offset = new Vector3(10f, 5f, -7f); // Distancia de la cámara a la bola


    void LateUpdate()
    {
        if (target != null)
        {
            // Mantener la cámara en la misma posición relativa a la bola, pero en diagonal
            transform.position = target.position + offset;

            // La cámara siempre mira a la bola
            transform.LookAt(target);
        }
    }
}

