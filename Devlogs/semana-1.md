# 🧟‍♂️ Farm Escape - Devlog Semana 1  
 ### 🚀 Progreso de la Semana:
 ---
 ### 🗺️ Avances en el Mapa
 He continuado desarrollando el mapa de la granja, dejando casi finalizada su primera versión funcional.
 
 Este es el primer registro de avances en el desarrollo de **Farm Escape**, un videojuego de supervivencia en tercera persona con control por voz.  
 Opté definitivamente por un estilo low poly para optimizar el rendimiento y acelerar el desarrollo.
 
 ## 🚀 Progreso de la Semana  
 Usé herramientas como Vertex Snapping (V) y alineación por grid para colocar objetos del entorno de forma precisa.
 
 ### ✅ Instalación y Configuración  
 - Instalé **Unity Hub** y configuré la versión **Unity 6000.0.43f1**.  
 - Tuve problemas con **Visual Studio** al no reconocer `MonoBehaviour`.  
   - Solución: Reinstalé los paquetes necesarios desde el **Visual Studio Installer** y regeneré los archivos del proyecto.  
 Añadí vallas y obstáculos para dar estructura al mapa, y estoy empezando a definir posibles rutas de escape para el jugador.
 
 ### 🎮 Aprendizaje y Estudios  
 - **IA y Pathfinding**  
   - Realicé el tutorial oficial de Unity:  
     [Beginner AI Pathfinding](https://learn.unity.com/project/beginner-ai-pathfinding)  
   - Aprendí sobre **NavMesh** y cómo controlar la IA.  
   - Exploré la posibilidad de usar **NavMesh** para controlar al jugador.  
   - Descubrí cómo gestionar animaciones mediante el **Animator**.  
 ### 🧠 IA y Mecánicas Básicas
 He implementado un sistema básico de enemigos con NavMesh, usando lo aprendido en el tutorial de la semana anterior.
 
 - **Ciclo de Vida de Unity**  
   - Estudié el orden de ejecución de los scripts en Unity para estructurar mejor mi código:  
     [Execution Order of Event Functions](https://docs.huihoo.com/unity/5.5/Documentation/Manual/ExecutionOrder.html)  
 Ahora, un zombi persigue al jugador y le hace daño al alcanzarlo.
 
 - **Modelado 3D Básico**  
   - Completé el tutorial **3D Essentials** para aprender a diseñar y personalizar objetos en Unity:  
     [Unity 3D Essentials](https://learn.unity.com/pathway/unity-essentials/unit/3d-essentials?version=6)  
 Este sistema ya funciona con colisiones y animaciones básicas, permitiendo probar el comportamiento del enemigo.
 
 ### 🔨 Creación del Mapa  
 - Instalé **ProBuilder** para construir, editar y personalizar el nivel de la granja.
 - Exploré referencias gráficas y busqué modelos 3D para ambientar el juego.  
 - Investigué en **Sketchfab** buscando elementos de decoración adecuados.
 - Instalé paquetes de assets Unity.
   
 ### 🛠️ Problema con las Texturas y Solución
 Tuve problemas con las texturas en Unity, ya que algunos materiales aparecían en color rosa debido a incompatibilidades con el Universal Render Pipeline (URP).
 ### 🔑 Objetos, Audio y Coleccionables
 He descargado nuevos assets para añadir coleccionables (como llaves) que permitan desbloquear zonas del mapa.
 
 📌 Solución aplicada:
 - 1️⃣ Seleccioné los materiales y texturas afectados.
 - 2️⃣ Fui a Rendering > Material > Convert para convertirlos al formato compatible con URP.
 - 3️⃣ Después de la conversión, los materiales volvieron a mostrarse correctamente en la escena.
 Comencé a trabajar en la integración del audio al recoger objetos y abrir puertas.
 
 🔎 Aprendizaje: Ahora entiendo mejor cómo funcionan los materiales en Unity y cómo ajustarlos para evitar errores al cambiar de render pipeline.
 ### 🎤 Reconocimiento de Voz
 Seguí investigando y puliendo el sistema de reconocimiento de voz.
 
 ### 🗺️ Creación del Mapa
 -He decidido optar por un estilo low poly para simplificar el desarrollo y optimizar el rendimiento.
 Después de varios intentos fallidos, descubrí que el problema era la versión por defecto de .NET.
 
 -He comenzado a diseñar el mapa, alineando objetos correctamente con el suelo utilizando Vertex Snapping (V) y la cuadrícula (CTRL/CMD).
 Cambié la configuración a .NET Framework (en lugar de .NET 2), lo que permitió que el sistema de dictado empezara a funcionar.
 
 ### 🎤 Pruebas con Reconocimiento de Voz
 -He empezado a experimentar con el dictado por voz para reconocer frases. De momento, las frases se detectan, pero aún no he logrado hacer que el sistema funcione correctamente para ejecutar acciones dentro del juego, sigo teniedno problemas con lo de la voz porque me recoge las frases pero no hace ninguna acción estoy analizando si uso microsoft speech recognition pero es un poco complejo.
 Ahora, el juego reconoce frases habladas y en algunos casos ejecuta acciones básicas como mover al jugador.
 
 Aunque todavía hay margen de mejora, este avance ha sido clave para continuar con la mecánica principal del juego.
 
 Seguiré investigando cómo mejorar la precisión del reconocimiento de voz.
 ---
 ### 📦 Gestión de Assets
 Me di cuenta de que los primeros paquetes de assets estaban incompletos.
 Descargué nuevos paquetes más completos y organizados para tener una mejor base visual.
 Esto incluye decoración, coleccionables, sonidos y modelos de mejor calidad.

 🔹 Conectar el sistema de reconocimiento de voz a comandos de juego completos (abrir puertas, atacar, interactuar, etc.).
 🔹 Terminar el mapa jugable con zonas bloqueadas/desbloqueables mediante llaves.
 🔹 Integrar animaciones más avanzadas para el jugador (caminar, correr, recibir daño).
