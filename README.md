# Práctica de Mecánicas 2D en Unity

Este proyecto implementa varias mecánicas fundamentales de un juego de plataformas 2D, desarrollando cada una de las tareas propuestas en el guion de la práctica. El objetivo es construir un script de control para el jugador que maneje el motor de físicas, las colisiones por capas y la interacción con objetos.

## Tarea 1: Salto y Detección de Suelo

La primera mecánica implementada fue el salto. Para lograrlo, el script del jugador aplica una fuerza vertical `AddForce` a su componente `Rigidbody 2D`.

Para evitar el salto infinito en el aire, se creó una etiqueta (Tag) "Suelo" y se asignó a las plataformas de suelo. El script utiliza `OnCollisionEnter2D` para detectar cuándo el jugador toca un objeto con esta etiqueta, permitiéndole volver a saltar.

_(Aquí iría img1: Se muestra el inspector de Unity con la capa de Suelo puesta en el tilemap del suelo.)_

_(Aquí iría gif1: Se muestra el salto en acción.)_

## Tarea 2: Plataformas Móviles

Para esta tarea, se creó un script que permite al jugador "pegarse" a plataformas en movimiento. Cuando el jugador aterriza sobre un objeto con la etiqueta "PlataformaMovil", el script lo convierte en hijo de la plataforma `transform.SetParent`. Al saltar o caerse, la relación de parentesco se rompe `transform.SetParent(null)`, permitiendo al jugador moverse libremente.

_(Aquí iría img2: Lo mismo pero con la de PlataformaMovil en una plataforma.)_

_(Aquí iría gif2: Se muestra el funcionamiento de la plataforma móvil.)_

## Tarea 3: Manejo de Colisiones por Capa (Ignorar Capas)

Esta tarea consistía en hacer que el jugador ignorase ciertos objetos. Para ello, se creó una capa (Layer) llamada "NoCollis".

_(Aquí iría img3: Se añade la capa NoCollis a una plataforma.)_

_(Aquí iría gif3: Se demuestra el NoCollis con una plataforma móvil.)_

## Tarea 4: Plataformas Invisibles

Para esta mecánica, se creó una nueva capa llamada "PlatInv". A las plataformas en esta capa se les desactivó su `Tilemap Renderer` para que fueran invisibles al inicio.

_(Aquí iría img4: Se añade la capa PlatInv y se desactiva el Tilemap Renderer de una plataforma.)_

Se añadió una lógica al script del jugador: al detectar una colisión (`OnCollisionEnter2D`) con un objeto en la capa "PlatInv", el script busca el componente `TilemapRenderer` y lo activa con `.enabled = true`, haciendo visible la plataforma.

_(Aquí iría gif4: Se muestra una plataforma invisible renderizándose con el contacto del jugador.)_

## Tarea 5: Mecánica de Recolección y Mejora

La tarea final fue implementar un sistema de puntuación. Se crearon objetos "moneda" con la etiqueta "Recolectable" y sus colliders configurados como `Is Trigger`.

_(Aquí iría img5: Se añade Recolectable a un objeto de moneda.)_

El script del jugador detecta estos triggers `OnTriggerEnter2D`, destruye la moneda y suma un punto. La puntuación se muestra en pantalla actualizando un componente de Texto de la UI.

_(Aquí iría img6: Se añade el texto de puntuación a la variable de TextoPuntuacion.)_

Además, al alcanzar los 5 puntos, el script modifica la variable `fuerzaDeSalto` del jugador, otorgándole un "buff" permanente que le permite saltar más alto.

_(Aquí iría gif5: Se muestra al jugador recogiendo las monedas, el marcador de puntuación subiendo y el buff de salto que se obtiene al recolectar las 5 monedas.)_
