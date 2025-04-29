
## Devlog Semana 4 (Actualización)
=======
# 🧟‍♂️ Farm Escape - Devlog Semana 4

### 🗝️ Sistema de Llaves

- Se creó un nuevo script `KeyPickup.cs` para representar llaves recolectables.
- Cada llave tiene un **nombre único** que se configura desde el Inspector (`keyName`).
- Al ser recolectada por el jugador:
  - Se añade ese nombre al array `keyNames` del `PlayerController`.
  - Se instancia un efecto de partículas como feedback visual.
  - Se destruye el objeto de la llave tras recogerla.

### 🚪 Controlador de Puertas

- Se implementó el script `DoorController.cs` para manejar puertas que requieren una llave específica.
- Cada puerta tiene una propiedad `keyRequired` (nombre de la llave que necesita).
- Usa un `Animator` que activa una animación al abrirse con el trigger `"open"`.
- Lógica:
  - Si el jugador entra en el `Trigger` y tiene la llave correspondiente en su lista `keyNames`, la puerta se abre.
  - Si no tiene la llave, se muestra un mensaje de advertencia en consola.
- Al abrirse:
  - Se desactiva el `Collider` de la puerta para permitir el paso.
  - También se desactiva el `NavMeshObstacle`, permitiendo el paso de NPCs o enemigos si fuera necesario.
  
### 🧱 Integración con Prefabs
- Se planifica que tenga una jerarquía con un objeto "Pivot" que permita la animación de apertura mediante rotación.
---

### 🛠️ Próximos Pasos

- Importar modelo de puerta con bisagra (pivot) para aplicar animación.
- Crear animación de apertura (puede ser rotación de 90° del pivot).
- Probar integración total entre el pickup de llave, la animación y desbloqueo de la puerta.

