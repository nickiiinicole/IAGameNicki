### 🧟‍♂️ Farm Escape - Devlog Semana 3
### 🚀 Progreso de la Semana
---
#### 🎤 Integración del Disparo por Voz

##### Hoy avancé con la funcionalidad de disparo controlado por voz, conectando comandos hablados directamente con animaciones del jugador, revisé el Animator del personaje y confirmé que tenía un Trigger llamado isShooting conectado correctamente a una animación de disparo. Añadí un nuevo comando "shoot" al sistema de reconocimiento por voz (KeywordRecognizer), que se activa al decirlo. Creé una función TriggerShootAnimation() dentro del PlayerController que dispara la animación con m_Animator.SetTrigger("isShooting"). Finalmente, conecté esta acción desde el VoiceCommandHandler, logrando que al decir "shoot" el personaje realice la animación de disparo automáticamente, pero la arma no esta bien colocada tengo que arreglar eso...

### 🔫 Prefab de Bala
##### Se creó un prefab de tipo bala (puede ser una esfera o modelo 3D con textura), con los siguientes componentes: Rigidbody (para moverse con física), Collider (para detectar colisiones), Script BulletController.cs (para movimiento y colisión)

### 🔄 Lógica de Disparo
##### Añadí el método TriggerShootAnimation() en el PlayerController, que activa la animación de disparo. Llama a Shoot() para instanciar y lanzar la bala.

### 🧟‍♂️ Daño al Enemigo
##### Las balas tienen un script BulletController.cs que detecta colisión con enemigos. Llama a un método en el enemigo para aplicar daño. Destruye la bala tras impactar.(EN ARREGLO:,))
