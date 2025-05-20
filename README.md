# 🧠 Farm Escape - Proyecto Final .NET
                    

¡Bienvenid@ al desarrollo de **Farm Escape**!  
🎮 Un juego de supervivencia con estilo *low poly*, donde exploras una granja abandonada y escapas usando tu **voz** para guiar al personaje.

---

## 📅 Reportes Semanales

Este documento contiene el resumen general del proyecto.  
Cada semana, publico un **devlog detallado** con avances 🛠️:

- 📘 [Semana 1 - Setup inicial y primeras ideas](Devlogs/semana-1.md)
- 📘 [Semana 2 - Reconocimiento de voz y mapa](Devlogs/semana-2.md)
- 📘 [Semana 3 - Enemigos, PickUps y más reconocimiento](Devlogs/semana-3.md)
- 📘 [Semana 4 - Sistema de llaves, puertas y prefabs](Devlogs/semana-4.md)
- 📘 [Semana 5 - Ajustes y mejoras generales](Devlogs/semana-5.md)
- 📘 [Semana 6 - *En proceso...*](Devlogs/semana-6.md)

---

## 🎮 Mecánicas Principales

- 🗣️ Movimiento por **comandos de voz** usando `KeywordRecognizer`.
- ⌨️ Alternativa de control por **teclado** (`↑ ↓ ← →` y `espacio`) para accesibilidad.
- 🔐 Zonas bloqueadas que se desbloquean con **llaves** coleccionables.
- 🧟‍♂️ **Enemigos con IA** que persiguen al jugador utilizando **NavMeshAgent**.
- 🧱 Diseño visual **low poly** hecho con ProBuilder.
- 🔫 Disparo y colisión con enemigos.
- 🎵 Efectos de sonido y feedback visual al recibir daño.
- 📜 Introducción estilo narrativa/rol al inicio del juego.

---

## 🛠️ Tecnologías y Herramientas

- 🎮 **Unity** 2021.3.6f1
- 🧠 **Reconocimiento de voz** con `UnityEngine.Windows.Speech`
- 🧭 **IA con NavMesh** para pathfinding
- 🧱 **ProBuilder** para diseño del mapa 3D
- 🎨 Assets de **Sketchfab**, Unity Asset Store y creadores externos
- 🧪 Corutinas (`IEnumerator`) para secuencias como diálogo, espera y efectos
- 💥 Efectos visuales con assets personalizados (daño, pickups, etc.)
- 🔊 Sonidos personalizados (pasos, disparo, daño, recogida…)

---

## 🧩 Instalación y Ejecución

1. Descarga la carpeta comprimida del proyecto desde [este enlace de Drive](https://drive.google.com/file/d/1myLKgdGfGisCNXlk4sgQ0AH0wGHpKFJp/view?usp=sharing).
2. Extrae el `.zip`.
3. Abre la carpeta y ejecuta el archivo `FarmEscape.exe`.
4. Acepta los permisos de micrófono cuando se muestren (si el sistema lo solicita).
5. ¡Listo! Comienza tu partida diciendo: **"adelante"**, **"gira izquierda"**, **"dispara"**, etc.

> **Nota**: Puedes jugar también con el teclado si tienes problemas con el micro.  

---

## 🔐 Permisos del Micrófono

Este juego necesita acceso al **micrófono** para el reconocimiento de comandos.  
En Windows, al ejecutar el juego por primera vez, aparecerá una ventana solicitando permiso.  
Si no ocurre o necesitas activarlo manualmente:

1. Pulsa `Windows + I` → Configuración.
2. Ve a **Privacidad y seguridad** → **Micrófono**.
3. Asegúrate de que *FarmEscape.exe* tiene acceso habilitado.

---
## 🎨 Créditos de Assets y Sonidos
### 👩‍💻 Autora

**Nicole Díaz**  
🎓 Proyecto final de DAM (.NET / Unity)

---
**Modelos y elementos gráficos**:
- GAMWILL – Zombie Shooter Series / Apocalypse Zombie Pack  
- CatBorg Studios – Zombies  
- AssetHunts – Personajes zombies  
- Dillon Wallace – Collectibles  
- Polyione Studio – Ammo / Armas  
- Matthew Guz – Hit Effects  
- PixelMush – Pixel Fonts: *TripfiveTiny Worlds*, *Thaleah*

**Sonidos y efectos**:
- Dpoggioli – Ammo Pickup  
- CosmicEmber – Trigger Pull  
- Mrickey13 – Player Hurt  
- Jtn191 – Healing Effect  
- LittleRobotS – Pickup Gold  

---

¡Gracias por jugar a *Farm Escape* :D!  
📦 ¡Proyecto creado con lágrimas, esfuerzo y un montón de zombies! 🧟‍♀️🧡

⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⣤⣤⣤⣤⣤⣤⣤⣤⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⠾⠛⠉⠉⠀⠀⠀⠀⠀⠀⢀⡤⠊⠉⠉⠛⠳⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⠾⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢮⡀⠀⠀⠀⠀⠀⠀⠙⢷⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⠟⡡⢤⠀⠀⠀⢰⣛⣉⣉⣓⠢⣄⠀⠀⠀⠈⢉⡁⠐⠒⠒⠂⠉⠉⠉⠛⢶⣄⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡞⠁⣘⡒⠁⢀⠀⠀⠀⣀⣀⣀⣈⣹⣾⣕⠀⢠⡎⠁⡹⠀⣠⠄⠀⠀⠀⠀⠀⠀⠙⢷⡀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢠⡟⢀⣎⡩⠃⢠⣏⡴⠞⠛⠉⠉⠀⠀⠀⠀⠹⡏⠀⠉⠉⣠⣾⠖⠋⠉⠻⣅⠀⣠⠖⢲⠌⢻⡄⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣿⡠⠔⢿⠀⢀⡟⠉⠀⠀⠀⣀⣤⣤⡀⠀⠀⠀⣿⠀⠀⠀⡼⠉⠉⠒⢦⣀⠘⠷⡛⠒⡿⣄⠈⣷⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢸⡏⠀⣠⠏⠀⢸⠀⠀⠀⠀⢰⣿⣿⣿⡇⠀⠀⢀⡿⠀⠀⣸⠃⠀⠀⣀⣄⡙⢷⣄⡇⠘⠀⢸⡆⢹⡀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢸⣧⠞⠁⠀⠀⢸⡆⠀⠀⠀⠸⣿⣿⡿⠃⠀⢀⣼⠃⠀⠀⣿⣆⠀⠀⣿⣿⡟⠀⠙⣧⠳⡤⠞⠀⢸⡇⠀⠀⠀⠀
⠀⢀⣠⠤⠤⢄⡀⠈⣧⢈⣧⠀⠀⢸⣿⣄⣀⣀⣠⣬⣥⠴⠶⢚⣿⠋⠀⠀⠀⢻⣿⣦⣄⠈⠁⠀⠀⣰⠟⠆⠀⠀⠀⢸⣡⠴⠖⠶⣦
⢠⠏⠀⠀⠀⢀⠈⠓⢿⡄⢳⠀⠀⠀⢳⣌⠻⠯⣤⣀⣀⣀⣴⣿⠏⢀⣶⢰⣦⠈⢿⣿⣿⣷⣀⣠⡼⠋⠀⢀⡀⠀⢀⣿⠥⢄⠀⠀⣿
⣏⠀⠀⠀⡟⢉⡽⣦⡈⢻⣼⠄⠀⠀⠀⠉⠓⠦⠤⠬⣏⣡⠾⠃⢀⣾⣿⢸⣿⣇⠈⠻⡯⠽⢯⡽⠁⠠⣴⠝⠃⢀⣾⢋⣁⠈⢀⡾⠃
⠘⠶⠲⢦⣷⠸⣤⣸⡇⠀⢻⣦⡀⠀⠀⠀⠀⠀⠀⠉⠁⠀⠀⠀⠘⠛⠋⠘⠋⠋⠀⠀⠑⠚⠉⠀⠀⠀⠈⣠⣠⡾⠳⠤⣿⡀⣾⠁⠀
⠀⠀⠀⠀⠸⢧⠉⠉⠀⢀⡾⠀⠉⠻⣦⠀⠀⠀⠈⢟⡽⠄⠀⠀⢀⣀⣤⣤⣤⣄⣀⠀⠀⠀⢀⡀⠀⠀⣴⡿⠛⠻⢶⣤⣿⡿⠋⠀⠀
⠀⠀⠀⠀⠀⠙⠒⠒⠚⠋⠀⠀⠀⠀⠸⣧⠀⠀⠀⠀⠁⠀⣠⣾⡿⢿⠀⠀⢀⣮⣙⡻⣦⡈⠙⠿⠀⣸⠏⠀⠀⠀⠀⢀⣿⣇⡀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⡆⠀⠀⠀⠀⣼⣿⣿⣇⣸⣷⣶⣾⡀⣯⣻⣿⣿⡄⠀⠀⡿⠀⠀⠀⠀⠀⢻⣾⡛⡇⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⡇⠀⠀⠀⠀⠀⠀⠛⠟⠁⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⠀⡀⠀⢸⣿⣿⡟⢻⡿⠿⣇⣿⢸⠿⣿⣿⣿⡏⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠐⡇⠀⠸⣯⠉⠙⠒⣃⣀⣈⣭⣭⣤⣀⣩⡟⠁⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡄⠃⠀⣀⣽⠷⠞⠛⠉⠉⠁⠀⣠⠤⠤⢤⣉⠙⠢⠤⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣧⠀⠘⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣶⠀⠹⠂⠀⣰⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠛⠛⠶⢦⣤⣀⣀⠀⠀⠀⠀⢀⣈⣛⣥⣤⠴⠾⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
