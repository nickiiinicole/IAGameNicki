# 🧟‍♂️ Farm Escape - Devlog Semana 1  

Este es el primer registro de avances en el desarrollo de **Farm Escape**, un videojuego de supervivencia en tercera persona con control por voz.  

## 🚀 Progreso de la Semana  

### ✅ Instalación y Configuración  
- Instalé **Unity Hub** y configuré la versión **Unity 6000.0.43f1**.  
- Tuve problemas con **Visual Studio** al no reconocer `MonoBehaviour`.  
  - Solución: Reinstalé los paquetes necesarios desde el **Visual Studio Installer** y regeneré los archivos del proyecto.  

### 🎮 Aprendizaje y Estudios  
- **IA y Pathfinding**  
  - Realicé el tutorial oficial de Unity:  
    [Beginner AI Pathfinding](https://learn.unity.com/project/beginner-ai-pathfinding)  
  - Aprendí sobre **NavMesh** y cómo controlar la IA.  
  - Exploré la posibilidad de usar **NavMesh** para controlar al jugador.  
  - Descubrí cómo gestionar animaciones mediante el **Animator**.  

- **Ciclo de Vida de Unity**  
  - Estudié el orden de ejecución de los scripts en Unity para estructurar mejor mi código:  
    [Execution Order of Event Functions](https://docs.huihoo.com/unity/5.5/Documentation/Manual/ExecutionOrder.html)  

- **Modelado 3D Básico**  
  - Completé el tutorial **3D Essentials** para aprender a diseñar y personalizar objetos en Unity:  
    [Unity 3D Essentials](https://learn.unity.com/pathway/unity-essentials/unit/3d-essentials?version=6)  

### 🔨 Creación del Mapa  
- Instalé **ProBuilder** para construir, editar y personalizar el nivel de la granja.
- Exploré referencias gráficas y busqué modelos 3D para ambientar el juego.  
- Investigué en **Sketchfab** buscando elementos de decoración adecuados.
- instalé paquetes de assets Unity.
  
### 🛠️ Problema con las Texturas y Solución
Tuve problemas con las texturas en Unity, ya que algunos materiales aparecían en color rosa debido a incompatibilidades con el Universal Render Pipeline (URP).

📌 Solución aplicada:
- 1️⃣ Seleccioné los materiales y texturas afectados.
- 2️⃣ Fui a Rendering > Material > Convert para convertirlos al formato compatible con URP.
- 3️⃣ Después de la conversión, los materiales volvieron a mostrarse correctamente en la escena.

🔎 Aprendizaje: Ahora entiendo mejor cómo funcionan los materiales en Unity y cómo ajustarlos para evitar errores al cambiar de render pipeline.

###🗺️ Creación del Mapa
-He decidido optar por un estilo low poly para simplificar el desarrollo y optimizar el rendimiento.

-He comenzado a diseñar el mapa, alineando objetos correctamente con el suelo utilizando Vertex Snapping (V) y la cuadrícula (CTRL/CMD).

###🎤 Pruebas con Reconocimiento de Voz
-He empezado a experimentar con el dictado por voz para reconocer frases. De momento, las frases se detectan, pero aún no he logrado hacer que el sistema funcione correctamente para ejecutar acciones dentro del juego.

Seguiré investigando cómo mejorar la precisión del reconocimiento de voz.
---

## 📌 Próximos Pasos  
🔹 Implementar el control del jugador mediante **reconocimiento de voz**.  
🔹 Crear una versión jugable del nivel con objetivos claros.  
---

📌 **Este README se actualizará semanalmente con los avances del proyecto.** 🚀  
