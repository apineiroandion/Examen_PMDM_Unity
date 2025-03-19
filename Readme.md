# Examen PMDM 2ª Evaluación

## Autor: Ángel José Piñeiro Andión

Este es el repsoitorio en el que voy a subir los scripts del examen.

## Unity:

### Utiliza el debug para detectar un contacto entre el cubo y la bola. ¿Que variantes puedes usar? (2 puntos)

1. En primer lugar etiqueto la bola como "Bola" y el cubo como "Cubo". Esta ultima etiqueta no la voy a utilizar por lo menos todavia, pero me parece util tener cada objeto correctamente etiquetado.

2. Como ambos tienen Collider y RigidBody creo el script "Colision" para el cubo. Donde la función OnCollisionEnter envia un mensaje de log cuando un objeto con el tag "Bola" entra en contacto con el cubo.

Otras opciones serian, hacerlo al reves, creando el Script en la bola y que mandara el log al entrar en contacto con un objeto "Cubo", usar un trigger con OnTriggerEnter en lugar de OnCollisionEnter. O utilizar la colision con OnCollisionExit enviando el mensaje cuando el objeto deja de estar en contacto.

### Que el cubo persiga a la bola como un enemigo (2 puntos)