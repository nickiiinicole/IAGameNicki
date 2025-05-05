# 🧟‍♂️ Farm Escape - Devlog Semana 5

---

## 🚀 Progreso General

Esta semana se avanzó en elementos esenciales de presentación y funcionalidad del juego. Se integró una **pantalla de carga personalizada**, se creó un **menú principal con animación** y se continuó con mejoras clave en **gameplay**, como puertas desbloqueables y recolección de llaves.

---

## 🎮 Menú Principal

- Nueva escena `MainMenu` con:
  - Botones de **Play**, **Opciones** y **Salir**.
  - Animación de fondo con un paisaje de granja difuminado.
  - Elemento decorativo (como un pájaro volando o movimiento suave de cámara). (Pendiente Corregir)
- Al pulsar **Play**, se transiciona a la escena `LoadingScene`.

---

## ⏳ Pantalla de Carga (Loading Screen)

- Se diseñó una escena `LoadingScene` con:
  - **Fondo negro**.
  - **Icono giratorio** (tractor nose si lo cambiare...).
- Uso de `SceneManager.LoadSceneAsync()` para cargar la escena del juego (`FarmFinal`) sin congelar la pantalla.

---

## 🗝️ Llaves Recolectables

- Se creó un **prefab de llave** y colocado en diferentes partes del mapa
---

## 🚪 Puertas con Llave

- Prefab de puerta con script `DoorController`:
  - Tiene un `string keyRequired`.
  - Comprueba si el jugador tiene la llave necesaria en `keyNames`.
  - Si la tiene, reproduce animación de abrir y desactiva el `NavMeshObstacle` y colisionador.
  - Si no, muestra mensaje de "🔒 Te falta la llave".
- Animación de apertura basada en rotación del eje Y interpolada con `Quaternion.Lerp`.

---

## 🧟‍♂️ Mejoras de Spawn y Items

- Se optimizó el sistema de spawn de enemigos (`EnemySpawner.cs`) con uso de `System.Random` para más aleatoriedad.
- Implementación de `PickupSpawner.cs`:
  - Controla aparición de pickups (salud, munición).
  - Respeta puntos fijos y asegura no repetir ubicaciones ocupadas.
  - Se puede reintegrar ubicación tras recoger.
  
---

## 🛠️ Otros Detalles Técnicos

- Se mejoraron animaciones de bala, daño y muerte.
- Se ajustaron animaciones de puerta y zombies.
- Se integró un `Animator` para abrir puertas con un solo trigger.

---

## 📌 Pendientes
- Ajustar colocación del arma del jugador.
- Mejorar animaciones
- Mostrar animación de daño con efectos en la UI
