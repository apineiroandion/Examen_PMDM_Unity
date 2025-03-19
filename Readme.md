# Examen PMDM 2ª Evaluación

## Autor: Ángel José Piñeiro Andión

Este es el repsoitorio en el que voy a subir los scripts del examen.

## Unity:

### Utiliza el debug para detectar un contacto entre el cubo y la bola. ¿Que variantes puedes usar? (2 puntos)

1. En primer lugar etiqueto la bola como "Bola" y el cubo como "Cubo". Esta ultima etiqueta no la voy a utilizar por lo menos todavia, pero me parece util tener cada objeto correctamente etiquetado.

2. Como ambos tienen Collider y RigidBody creo el script "Colision" para el cubo. Donde la función OnCollisionEnter envia un mensaje de log cuando un objeto con el tag "Bola" entra en contacto con el cubo.

Otras opciones serian, hacerlo al reves, creando el Script en la bola y que mandara el log al entrar en contacto con un objeto "Cubo", usar un trigger con OnTriggerEnter en lugar de OnCollisionEnter. O utilizar la colision con OnCollisionExit enviando el mensaje cuando el objeto deja de estar en contacto.

### Que el cubo persiga a la bola como un enemigo (2 puntos)

1. Instalamos AI Navigation desde el Package Manager

2. Creo un nuevo Game Object vacio al que llamo "Enemigo" sobre el cual arrastro el cubo que teniamos creado previamente, de modo que actue como el cuerpo del enemigo.

3. Selecciono el plano de juego, al que habia llamado "Ground" y le incluyo el componente NavMeshSurface

4. Desde la pestaña de Inspect, y dentro del apartado de NavMeshSurface abro el desplegable de CollectObjects y marco CurrentObjectHierarchy y le doy al botón bake.

5. Vuelvo a seleccionar el objeto "Enemigo" y le añado el componente NavMeshAgent.

6. Creo un nuevo script en el enemigo llamado "EnemyMovement", y le copio el codigo del script del tutorial de RollaBall, ya que es perfectamente funcional para este caso.

Con esto ya tenemos al cubo persiguiendo a la bola.

### Hay dos estados: “lejos” y “cerca”. Según la posición de la bola respecto al cubo, cambia el estado (2 puntos)

### Sin animator!

 1. Creo un enum PlayerState dento del scrip BallMovement, donde voy a definir los estados "cerca", "lejos" y "sinDefinir"
 
 2. Creo un atributo del tipo PlayerState llamado "state" que define el estado actual de la bola.
 
 3. Añado las referencias al objeto etiquetado como cubo y defino la distancia que se considera cerca (2f) 

 4. Dentro update() defino la varaible distancia que calcula la diferencia de la posicion entre ambos objetos, y creo un if donde si la distancia es menos a la distanciaUmbral cambia el estado a cerca y manda un log avisando de que la bola esta creaca, y si no cambia el estado a lejos y manda un log diciendo que la bola esta lejos.

 ### Con la configuración de una cámara en primera persona, añádele la posibilidad de que cuando se presione la tecla “1” la camara haga una panorámica lenta de 360º, volviendo a la posición inicial (2 puntos)

1. Para esto creo una nueva camara a la que llamo "CamaraPrimeraPersona" y desactivo la anterior desde el check de la vetnana de Inspector

2. Creo un nuevo script, y utilizo como base el script de la camara en primera persona que tenia creado para el proyecto de Unity.

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

            // Start is called before the first frame update
            void Start()
            {
                // Calcular la distancia entre la cámara y el jugador
                offset = transform.position - player.transform.position;
            }

            // LateUpdate se llama después de que se hayan procesado todos los objetos en la escena
            void LateUpdate()
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

3. A este codigo le añado un booleano isRotating que actua como estado, de forma que si la camara ya esta rotando no podamos hacerlo mas veces, y en el update, detecto si se pulsa la tecla "1" y si isRotating no es falso, para empezar la corutina RotateCamera()

4. Por ultimo creo la corrutina de la siguiente mantera:
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






