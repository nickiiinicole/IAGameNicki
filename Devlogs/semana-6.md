# 🧟‍🌾 Progreso Semanal 6 - *Farm Escape*

¡Última semana y muchas mejoras finales antes de cerrar el proyecto! 🎉

---

## 🔹 Mejoras en el Movimiento y Control del Jugador

- Añadido soporte para **teclas de control** como alternativa a los comandos de voz, mejorando la accesibilidad:
  - `↑ ↓ ← →` para movimiento básico.
  - `Espacio` para detenerse.

- 🐞 **Bug resuelto**: el modelo visual del jugador se desincronizaba al retroceder.  
  - Causa: solo se movía el objeto hijo (mesh), no el objeto raíz con el `NavMeshAgent`.

---

## 🔹 IA y Spawns de Enemigos

- Ajustado el sistema de aparición de zombis:
  - Ahora los primeros enemigos aparecen correctamente en la zona inicial.
  - Reorganizados los **puntos de spawn** para evitar solapamientos o zonas vacías.
  - Reparada la colisión de las balas, que antes no impactaban correctamente.

- ⚙️ Aumentada la cantidad de enemigos para generar una dificultad más progresiva.

---

## 🔹 Sistema de Daño, Vida y Game Over

- 🧠 Corregido el bug donde el estado `"Dead"` quedaba en bucle infinito.

- Añadido un **sistema de regeneración de vida** (fase de pruebas).

- Ajustado:
  - Tiempo de daño recibido.
  - Velocidad y respuesta de las animaciones (`Animator`).

- 🔴 Se implementó un overlay visual de daño, aunque fue eliminado por razones estéticas.

---

## 🎨 Mejoras Visuales y Estéticas

- Texturas y materiales reimportados manualmente por errores en el proceso.

- Personalizado el color de **tablas de madera** para ambientación más cálida.

- Añadidos detalles decorativos:
  - Assets de partículas.
  - Elementos del entorno (barriles, vegetación, herramientas...).

- Nuevas **animaciones de prueba** para movimientos laterales y giros (en desarrollo).

---

## 🎤 Reconocimiento de Voz

- Documentado cómo **activar el permiso del micrófono**:  
  - `Win + I → Privacidad → Micrófono`.

- ⚠️ Bug resuelto: el sistema fallaba debido al uso por defecto de `.NET 2.0`.  
  - Se cambió a **.NET Framework** compatible con `System.Speech`.

- Implementado `GrammarRecognizer` (fase experimental).

---

## 💥 Efectos y Audio

- 🎧 Sonidos añadidos para eventos clave:
  - Disparos, daño recibido, recogida de objetos, apertura de puertas.

- Sistema mejorado:
  - Control de volumen.
  - Reproducción espacial (audio 3D en Unity).

---

## 📦 Recursos y Assets

- Nuevos assets descargados:
  - Partículas, armas, sonidos, decoración, efectos.

- 🧹 Limpieza del proyecto:
  - Organización de carpetas.
  - Jerarquía más limpia y estructurada.

---

## 📚 Aprendizajes Técnicos

Esta semana profundicé en:

- Corutinas e `IEnumerator` para manejar delays y pantallas de carga.
- Animaciones (`SetTrigger`, `SetBool`) y su sincronización con acciones del jugador.
- Uso conjunto de `NavMesh`, `Rigidbody` y `Collider`.
- Diseño modular del mapa con **ProBuilder**.
- Reconocimiento de comandos de voz:
  - `KeywordRecognizer` y `GrammarRecognizer`.

---

## ✅ Cosas Completadas esta Semana

✔️ Sistema híbrido de control (voz + teclado).  
✔️ Bug del movimiento hacia atrás corregido.  
✔️ IA inicial y spawns ajustados.  
✔️ Daño, colisiones y muerte reparados.  
✔️ Mejora de estética del mapa y ambientación.  
✔️ Documentación sobre permisos de micrófono y configuración de framework.

---

**¡Semana final completada con éxito!**  
¡Zombies derrotados y proyecto entregado! 🧟‍♀️✅
