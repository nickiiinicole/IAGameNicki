### 🧟‍♂️ Farm Escape - Devlog Semana 2
 ### 🚀 Progreso de la Semana
 ### 🗣️ Integración del Reconocimiento de Voz al Jugador
 Esta semana me enfoqué en integrar el sistema de reconocimiento de voz con el movimiento del personaje principal utilizando KeywordRecognizer de Unity.
 
 ### 🗺️ Avances en el Mapa
 He continuado desarrollando el mapa de la granja, dejando casi finalizada su primera versión funcional.
 
 Opté definitivamente por un estilo low poly para optimizar el rendimiento y acelerar el desarrollo.
 
 Usé herramientas como Vertex Snapping (V) y alineación por grid para colocar objetos del entorno de forma precisa.
 
 Añadí vallas y obstáculos para dar estructura al mapa, y estoy empezando a definir posibles rutas de escape para el jugador.
 Usé herramientas como Vertex Snapping (V) y alineación por grid para colocar objetos del entorno de forma precisa. Añadí vallas y obstáculos para dar estructura al mapa, y estoy empezando a definir posibles rutas de escape para el jugador.
 
 ### 🧠 IA y Mecánicas Básicas
 He implementado un sistema básico de enemigos con NavMesh, usando lo aprendido en el tutorial de la semana anterior.
 
 Ahora, un zombi persigue al jugador y le hace daño al alcanzarlo.
 
 He implementado un sistema básico de enemigos con NavMesh, usando lo aprendido en el tutorial de la semana anterior. Ahora, un zombi persigue al jugador y le hace daño al alcanzarlo.
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
 
 Seguí investigando y puliendo el sistema de reconocimiento de voz. Después de varios intentos fallidos, descubrí que el problema era la versión por defecto de .NET. Cambié la configuración a .NET Framework (en lugar de .NET 2), lo que permitió que el sistema de dictado empezara a funcionar. Ahora, el juego reconoce frases habladas y en algunos casos ejecuta acciones básicas como mover al jugador.
 Aunque todavía hay margen de mejora, este avance ha sido clave para continuar con la mecánica principal del juego.
 
 ## 🧠 Uso de KeywordRecognizer
 @@ -40,20 +26,22 @@ El sistema de KeywordRecognizer se implementó con éxito, permitiendo al juego
 ## 🔧 Problemas con GrammarRecognizer
 Intenté integrar el sistema de reconocimiento de frases estructuradas utilizando un archivo XML de gramática (GrammarWithSemantics.xml), pero me encontré con varios problemas:
 
 - El sistema lanzó el error GrammarCompilationFailure al intentar compilar la gramática, lo que impidió el uso de frases complejas. Probé varias soluciones, pero la integración no funcionó como esperaba. La solución temporal que tengo es que dado que el uso de KeywordRecognizer estaba funcionando correctamente, decidí continuar con él, eliminando la parte de GrammarRecognizer por ahora. A pesar de que la detección de palabras clave es limitada, esta solución está permitiendo que se reconozcan acciones básicas como las que mencione anteriormente
 El sistema lanzó el error GrammarCompilationFailure al intentar compilar la gramática, lo que impidió el uso de frases complejas. Probé varias soluciones, pero la integración no funcionó como esperaba. La solución temporal que tengo es que dado que el uso de KeywordRecognizer estaba funcionando correctamente, decidí continuar con él, eliminando la parte de GrammarRecognizer por ahora. A pesar de que la detección de palabras clave es limitada, esta solución está permitiendo que se reconozcan acciones básicas como las que mencione anteriormente
 
 ## ⚙️ Implementación técnica
 Creé un script llamado VoiceCommandHandler.cs encargado de escuchar comandos de voz y enviar acciones al PlayerController. Usé un Dictionary<string, Action> para mapear comandos como "play", "stop", "avanzar", "hacia atrás", etc. a funciones específicas. 
 
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
 
  Conectar el sistema de reconocimiento de voz a comandos de juego completos (abrir puertas, atacar, interactuar, etc.).
 - 🔹Terminar el mapa jugable con zonas bloqueadas/desbloqueables mediante llaves.
 - 🔹Integrar animaciones más avanzadas para el jugador (caminar, correr, recibir daño).
 - 🔹Mejorar la detección de comandos: Continuaré investigando sobre cómo resolver el problema con el GrammarRecognizer para reconocer frases más complejas.
 - 🔹Integración de acciones más avanzadas: Planeo conectar los comandos reconocidos con acciones específicas del juego, como disparar o interactuar con objetos.
 - 🔹Asociar más comandos a otras acciones (abrir puertas, atacar, interactuar con objetos). Integrar animaciones al moverse por voz.
 - 🔹Hacer que el sistema reconozca frases más naturales y no solo palabras clave.
