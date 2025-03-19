using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2 : MonoBehaviour
{   
    public GameObject player;
    private Vector3 offset;

    public float sensitivityX = 2f;
    public float sensitivityY = 2f;
    public float minimumY = -60f;
    public float maximumY = 60f;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private bool isRotating = false; // Para evitar múltiples rotaciones al mismo tiempo

    void Start()
    {
        offset =player.transform.position;
    }

    void Update()
    {
        // Detectar la tecla "1" y empezar la rotación si no está en curso
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isRotating)
        {
            StartCoroutine(RotateCamera());
        }
    }

    void LateUpdate()
    {
        if (!isRotating)
        {
            // Obtener el movimiento del ratón
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;

            // Limitar la rotación vertical
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            // Rotar la cámara
            transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);

            // Actualizar la posición de la cámara manteniendo el offset
            transform.position = player.transform.position + offset;
        }
    }

    IEnumerator RotateCamera()
    {
        isRotating = true;
        float duration = 1.0f; // Tiempo en segundos para completar la rotación
        float elapsedTime = 0f;
        float startRotation = rotationX;
        float targetRotation = startRotation + 360f; // Rotar 360 grados

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            rotationX = Mathf.Lerp(startRotation, targetRotation, elapsedTime / duration);
            transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);
            yield return null;
        }

        rotationX = targetRotation % 360f; // Asegurar que no se acumulen valores grandes
        isRotating = false;
    }
}
