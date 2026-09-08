# Realidad Virtual: Metáforas de Movimiento en Gravedad Zero con Retroalimentación Háptica

Simulador y videojuego de realidad virtual en entorno espacial desarrollado en Unity. El proyecto implementa un sistema de locomoción personalizado con físicas en gravedad 0, integración de un chaleco háptico bHaptics y la mecánica de portales no euclidianos adaptados a VR.

---

## Autores

* **Andrés González Antohi**
* **Rodrigo Hervada Llahosa**
* **Marco Sánchez Nishimura**

---

## Características Principales

* **Locomoción en Gravedad Cero:**
  * Control tipo FPS mediante el sistema *Action-Based* de Unity.
  * Movimiento horizontal, ascención/descenso vertical y rotación basados en `Rigidbody` (`AddRelativeForce` / `AddRelativeTorque`).
  * Botón de frenado progresivo (*Panic Button*) para anular la inercia sin generar mareos.
  * Reducción de mareo en VR (*Virtual Reality Sickness*) mediante técnica de **Tunneling / Vignette**.

* **Retroalimentación Háptica (bHaptics):**
  * Integración de chaleco háptico mediante **bHaptics SDK2**.
  * Vibraciones de jetpack activadas mediante eventos personalizados.
  * Detección de colisiones físicas procesadas de forma independiente para cada uno de los 40 motores del chaleco.

* **Puzles e Interacciones en VR:**
  * **Sistema de herramientas:** Dispensador de objetos ilimitados e integración de cinturón para transporte mediante `XR Socket Interactor`.
  * **Puzle del Fusible:** Apertura de caja de conexiones mediante desatornillador y colocación de fusibles.
  * **Puzle del Teclado:** Teclado interactivo de 11 teclas basado en botones táctiles (*XR Simple Interactable*).

* **Mecánica de Portales:**
  * Transición espacial entre zonas mediante la técnica de *Render Texture* y *Unlit Shaders*.
  * Lógica matemática personalizada para rotación, posición relativa y teletransporte manteniendo la velocidad vectorial del jugador.
  * Colocación dinámica de portales en tiempo real lanzando un *Raycast* a través de una pistola de portales interactiva.

---

## Tecnologías y Requisitos

* **Motor:** Unity (con *XR Interaction Toolkit* y *XR Plug-in Management*)
* **Dispositivo HMD:** PICO 4 (compatible con *PICO Unity Integration SDK* y *PICO Live Preview Plugin*)
* **Hardware Háptico:** Chaleco bHaptics (*bHaptics Player*, *bHaptics Developer Portal*, *bHaptics Designer*)
