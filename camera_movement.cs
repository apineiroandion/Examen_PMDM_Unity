using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public Transform target; // La bola
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Distancia de la cámara a la bola

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset; // Sigue la bola manteniendo la distancia
            transform.LookAt(target); // Hace que la cámara mire a la bola
        }
    }
}
