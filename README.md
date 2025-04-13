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

Todavia no he comenzado:,) a trabajar en la integración del audio al recoger objetos y abrir puertas.

### 🎤 Reconocimiento de Voz
Seguí investigando y puliendo el sistema de reconocimiento de voz.

Después de varios intentos fallidos, descubrí que el problema era la versión por defecto de .NET.

Cambié la configuración a .NET Framework (en lugar de .NET 2), lo que permitió que el sistema de dictado empezara a funcionar.

Durante esta semana, he estado trabajando en la integración del sistema de reconocimiento de voz en Unity, utilizando Windows Speech Recognition.

Ahora, el juego reconoce frases habladas y en algunos casos ejecuta acciones básicas como mover al jugador.

Aunque todavía hay margen de mejora, este avance ha sido clave para continuar con la mecánica principal del juego.

## 🧠 Uso de KeywordRecognizer
El sistema de KeywordRecognizer se implementó con éxito, permitiendo al juego reconocer palabras clave predefinidas como: play, stop, pause, avanzar, hacia adelante, hacia atrás, izquierda, derecha.

## 🔧 Problemas con GrammarRecognizer
Intenté integrar el sistema de reconocimiento de frases estructuradas utilizando un archivo XML de gramática (GrammarWithSemantics.xml), pero me encontré con varios problemas:

- El sistema lanzó el error GrammarCompilationFailure al intentar compilar la gramática, lo que impidió el uso de frases complejas. Probé varias soluciones, pero la integración no funcionó como esperaba. La solución temporal que tengo es que dado que el uso de KeywordRecognizer estaba funcionando correctamente, decidí continuar con él, eliminando la parte de GrammarRecognizer por ahora. A pesar de que la detección de palabras clave es limitada, esta solución está permitiendo que se reconozcan acciones básicas como las que mencione anteriormente

### 📦 Gestión de Assets
Me di cuenta de que los primeros paquetes de assets estaban incompletos.

Descargué nuevos paquetes más completos y organizados para tener una mejor base visual.

Esto incluye decoración, coleccionables, sonidos y modelos de mejor calidad.

### 📌 Próximos Pasos
🔹 Conectar el sistema de reconocimiento de voz a comandos de juego completos (abrir puertas, atacar, interactuar, etc.).
🔹 Terminar el mapa jugable con zonas bloqueadas/desbloqueables mediante llaves.
🔹 Integrar animaciones más avanzadas para el jugador (caminar, correr, recibir daño).
🔹 Mejorar la detección de comandos: Continuaré investigando sobre cómo resolver el problema con el GrammarRecognizer para reconocer frases más complejas.
🔹 Integración de acciones más avanzadas: Planeo conectar los comandos reconocidos con acciones específicas del juego, como disparar o interactuar con objetos.

📌 **Este README se actualizará semanalmente con los avances del proyecto.** 🚀  
