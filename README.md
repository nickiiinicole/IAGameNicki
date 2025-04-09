### 🧟‍♂️ Farm Escape - Devlog Semana 2
### 🚀 Progreso de la Semana
### 🗺️ Avances en el Mapa
He continuado desarrollando el mapa de la granja, dejando casi finalizada su primera versión funcional.

Opté definitivamente por un estilo low poly para optimizar el rendimiento y acelerar el desarrollo.

Usé herramientas como Vertex Snapping (V) y alineación por grid para colocar objetos del entorno de forma precisa.

Añadí vallas y obstáculos para dar estructura al mapa, y estoy empezando a definir posibles rutas de escape para el jugador.

### 🧠 IA y Mecánicas Básicas
He implementado un sistema básico de enemigos con NavMesh, usando lo aprendido en el tutorial de la semana anterior.

Ahora, un zombi persigue al jugador y le hace daño al alcanzarlo.

Este sistema ya funciona con colisiones y animaciones básicas, permitiendo probar el comportamiento del enemigo.

### 🔑 Objetos, Audio y Coleccionables
He descargado nuevos assets para añadir coleccionables (como llaves) que permitan desbloquear zonas del mapa.

Comencé a trabajar en la integración del audio al recoger objetos y abrir puertas.

### 🎤 Reconocimiento de Voz
Seguí investigando y puliendo el sistema de reconocimiento de voz.

Después de varios intentos fallidos, descubrí que el problema era la versión por defecto de .NET.

Cambié la configuración a .NET Framework (en lugar de .NET 2), lo que permitió que el sistema de dictado empezara a funcionar.

Ahora, el juego reconoce frases habladas y en algunos casos ejecuta acciones básicas como mover al jugador.

Aunque todavía hay margen de mejora, este avance ha sido clave para continuar con la mecánica principal del juego.

### 📦 Gestión de Assets
Me di cuenta de que los primeros paquetes de assets estaban incompletos.

Descargué nuevos paquetes más completos y organizados para tener una mejor base visual.

Esto incluye decoración, coleccionables, sonidos y modelos de mejor calidad.

### 📌 Próximos Pasos
🔹 Conectar el sistema de reconocimiento de voz a comandos de juego completos (abrir puertas, atacar, interactuar, etc.).
🔹 Terminar el mapa jugable con zonas bloqueadas/desbloqueables mediante llaves.
🔹 Integrar animaciones más avanzadas para el jugador (caminar, correr, recibir daño).

📌 **Este README se actualizará semanalmente con los avances del proyecto.** 🚀  
