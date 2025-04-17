### 🧟‍♂️ Farm Escape - Devlog Semana 3
---
### 🚀 Progreso de la Semana

#### 🎤 Integración del Disparo por Voz
Hoy avancé con la funcionalidad de disparo controlado por voz, conectando comandos hablados directamente con animaciones del jugador, revisé el Animator del personaje y confirmé que tenía un Trigger llamado isShooting conectado correctamente a una animación de disparo. Añadí un nuevo comando "shoot" al sistema de reconocimiento por voz (KeywordRecognizer), que se activa al decirlo. Creé una función TriggerShootAnimation() dentro del PlayerController que dispara la animación con m_Animator.SetTrigger("isShooting"). Finalmente, conecté esta acción desde el VoiceCommandHandler, logrando que al decir "shoot" el personaje realice la animación de disparo automáticamente, pero la arma no esta bien colocada tengo que arreglar eso...
