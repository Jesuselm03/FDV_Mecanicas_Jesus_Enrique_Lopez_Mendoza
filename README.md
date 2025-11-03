# Práctica de Mecánicas 2D en Unity

Este proyecto implementa varias mecánicas fundamentales de un juego de plataformas 2D, desarrollando cada una de las tareas propuestas en el guion de la práctica. El objetivo es construir un script de control para el jugador que maneje el motor de físicas, las colisiones por capas y la interacción con objetos.

## Tarea 1: Salto y Detección de Suelo

La primera mecánica implementada fue el salto. Para lograrlo, el script del jugador aplica una fuerza vertical `AddForce` a su componente `Rigidbody 2D`.

Para evitar el salto infinito en el aire, se creó una etiqueta (Tag) "Suelo" y se asignó a las plataformas de suelo. El script utiliza `OnCollisionEnter2D` para detectar cuándo el jugador toca un objeto con esta etiqueta, permitiéndole volver a saltar.

<img width="577" height="62" alt="img1" src="https://github.com/user-attachments/assets/bb20c51f-2511-496e-bc7f-0c07657b3cb5" />

![gif1](https://github.com/user-attachments/assets/b9b17f7d-3129-4250-b384-b87858aa72ea)

## Tarea 2: Plataformas Móviles

Para esta tarea, se creó un script que permite al jugador "pegarse" a plataformas en movimiento. Cuando el jugador aterriza sobre un objeto con la etiqueta "PlataformaMovil", el script lo convierte en hijo de la plataforma `transform.SetParent`. Al saltar o caerse, la relación de parentesco se rompe `transform.SetParent(null)`, permitiendo al jugador moverse libremente.

<img width="576" height="72" alt="img2" src="https://github.com/user-attachments/assets/25ec73bc-b6f5-4adb-82b3-8ea02feb21b8" />

![gif2](https://github.com/user-attachments/assets/1ab3ad4a-5297-4ea7-962a-9112c6604e29)

## Tarea 3: Manejo de Colisiones por Capa (Ignorar Capas)

Esta tarea consistía en hacer que el jugador ignorase ciertos objetos. Para ello, se creó una capa (Layer) llamada "NoCollis".

<img width="571" height="63" alt="img3" src="https://github.com/user-attachments/assets/322158e6-06a7-4846-811d-60f9521924aa" />

![gif3](https://github.com/user-attachments/assets/98685f24-ca6f-4f09-9a95-94ce3c9e3620)

## Tarea 4: Plataformas Invisibles

Para esta mecánica, se creó una nueva capa llamada "PlatInv". A las plataformas en esta capa se les desactivó su `Tilemap Renderer` para que fueran invisibles al inicio.

<img width="597" height="706" alt="img4" src="https://github.com/user-attachments/assets/0e8f7f42-09a7-41bf-815e-3adfe8885769" />

Se añadió una lógica al script del jugador: al detectar una colisión (`OnCollisionEnter2D`) con un objeto en la capa "PlatInv", el script busca el componente `TilemapRenderer` y lo activa con `.enabled = true`, haciendo visible la plataforma.

![gif4](https://github.com/user-attachments/assets/36fea0f1-a46f-47a5-af15-9ca274c4b381)

## Tarea 5: Mecánica de Recolección y Mejora

La tarea final fue implementar un sistema de puntuación. Se crearon objetos "moneda" con la etiqueta "Recolectable" y sus colliders configurados como `Is Trigger`.

<img width="577" height="67" alt="img5" src="https://github.com/user-attachments/assets/9a103bf6-225b-4a70-86e5-d31e262f107a" />

El script del jugador detecta estos triggers `OnTriggerEnter2D`, destruye la moneda y suma un punto. La puntuación se muestra en pantalla actualizando un componente de Texto de la UI.

<img width="583" height="196" alt="img6" src="https://github.com/user-attachments/assets/14605e2c-0997-473a-ab03-1ea11e833b4f" />

Además, al alcanzar los 5 puntos, el script modifica la variable `fuerzaDeSalto` del jugador, otorgándole un "buff" permanente que le permite saltar más alto.

![gif5](https://github.com/user-attachments/assets/a3daf47b-1032-41ab-bcc7-da89c795ad83)
