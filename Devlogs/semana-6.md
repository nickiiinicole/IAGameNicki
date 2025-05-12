# Progreso Semanal 6🧟‍🌾

### 🔹 Movimiento suave hacia un objetivo (PlayerFollow)
- Se creó el script `PlayerFollow.cs`, que mueve suavemente un GameObject hacia un objetivo (`playerTarget`) usando `Vector3.Lerp`.
- Se configuraron variables públicas para ajustar la **velocidad de seguimiento** (`followSpeed`) y la **distancia mínima** (`stoppingDistance`) en el Inspector.

### 🔹 Apertura de puertas con Slerp (DoorController)
- Las puertas giran suavemente usando interpolación esférica (`Quaternion.Slerp`) entre dos ángulos.
- Se controla el acceso a la puerta mediante llaves (`keyRequired`) asociadas al jugador.
- Al abrirse, se desactiva un `NavMeshObstacle` para permitir el paso del jugador.

### 🔹 Menú en la misma escena (MainMenuController)
- El menú principal está embebido en la misma escena del juego, sin necesidad de cargar una nueva escena.
- Al pulsar el botón **Play**, se oculta el menú (`SetActive(false)`).
- Incluye también opciones de configuración y salida del juego con `Application.Quit()`.

### ⏳ Pantalla de Carga (Loading Screen, pero puede ser que la quite....)
- Implementé una **pantalla de carga personalizada** entre el menú y el juego.
- Aprendí a usar las **corutinas** (`IEnumerator`) para cargar escenas de forma asincrónica, evitando que el juego se congele.
- Probé ideas como zombies caminando en la pantalla, pero decidí simplificarlo por estética y rendimiento.
- Finalmente, dejé un fondo con una **imagen generada estilo low-poly 3D** y un **slider de progreso** que indica la carga. (Todavía no se si lo dejare así o lo quitare...)

### 🧍‍♂️ Ajustes Controlador del Jugador
- Trabajé de nuevo en el script que controla al personaje principal usando **NavMeshAgent** y el sistema de animaciones de **ThirdPersonCharacter**.

### 💥 Daño y Efectos Visuales
  - Planeé un sistema de **efecto visual tipo splash de sangre** que aparece en pantalla cuando recibe daño. (Pero lo quitare porque siento que no concuerda con la temática)
  - Este sistema irá mostrando overlays rojos PNG (ya tengo la imagen), aumentando la intensidad con cada golpe.

### 🧠 Aprendizajes Técnicos
- Corutinas: aprendí a usarlas para procesos asincrónicos (como cargar escenas sin freeze).
- Entendí cómo usar `SceneManager.LoadSceneAsync()` junto a una barra de progreso.
- Mejor manejo del sistema de UI (eventos `OnClick`, sliders, imágenes overlay).
- También toqué algo de animaciones con `Animator.SetTrigger` y `SetBool`.

---

## Cosas Pendientes
- Pulir animaciones y direcciones del jugador
- Revisar pequeños bugs como movimiento de zombies o posición inicial de los spawns.
---

**¡Seguimos avanzando!** 🚜🧟‍♂️
