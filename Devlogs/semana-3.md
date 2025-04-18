# 🧟‍♂️ Farm Escape - Devlog Semana 3

---

## 🚀 Progreso General

Esta semana avancé principalmente con **la integración de comandos de voz**, el **sistema de disparo del jugador**, y la **gestión de enemigos instanciados dinámicamente**.

---

## 🎤 Reconocimiento de Voz Integrado

- Implementé un sistema de reconocimiento de voz usando `KeywordRecognizer` de Unity.
- Agregué comandos como `"play"`, `"stop"`, `"avanzar"`, `"hacia atrás"` y `"shoot"` para controlar al jugador con la voz.
- Creé la clase `VoiceCommandHandler` que mapea las frases a funciones del `PlayerController` como `MoveTo()`, `StopMovement()` y `TriggerShootAnimation()`.
- Validé la funcionalidad en escena, incluyendo animaciones al moverse y disparar.
- Analicé documentación de Unity y tutoriales oficiales sobre `UnityEngine.Windows.Speech`.

---

## 🔫 Sistema de Disparo 

- Añadí un método `TriggerShootAnimation()` en el `PlayerController`, que dispara la animación mediante `m_Animator.SetTrigger("isShooting")`.
- En `VoiceCommandHandler`, vinculé el comando `"shoot"` con esta animación.
- A futuro, planeo mejorar la colocación del arma para que coincida visualmente con la animación.

---

## 💥 Prefab de Bala

- Se creó un `Prefab` llamado **Bala**, compuesto por:
  - Un `Rigidbody` para aplicar física.
  - Un `Collider` para detectar colisiones.
  - Un script `BulletController.cs` que:
    - Controla el movimiento de la bala.
    - Detecta colisiones con enemigos.
    - Llama a `TakeDamage()` en el enemigo.
    - Instancia partículas y destruye la bala tras impactar.

---

## 🧟‍♂️ Sistema de Daño y Enemigos

- Los enemigos ahora tienen salud, y reciben daño correctamente al ser impactados por las balas.
- Se agregaron animaciones de daño y muerte en el `EnemyController`, usando triggers como `"isHurting"` y `"dead"`.
- Se implementó una función `TakeDamage(float)` que gestiona la vida del enemigo y activa la animación adecuada.
- Se destruyen automáticamente luego de morir tras cierto tiempo.

---

## 🧠 Enemy Spawner

- Implementé un `EnemySpawner.cs` que:
  - Instancia enemigos cada X segundos (`timeWindow`).
  - Usa una lista de `Transform` para las posiciones de aparición.
  - Limita la cantidad de enemigos en escena (`enemiesAmountLimit`).
- Cada enemigo tiene un `EnemySpawnerHelper` que notifica al spawner al morir, reduciendo el contador de enemigos activos.

---

## ⚙️ Pendientes y Observaciones

- Alinear mejor el arma del jugador con la animación.
- Animación de caminar de los enemigos dejó de funcionar al implementar el spawner (fue corregido).
- Mejorar efectos visuales (impactos, partículas de sangre, etc.).
