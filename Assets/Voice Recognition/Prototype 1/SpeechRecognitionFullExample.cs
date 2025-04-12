using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;

public class SpeechRecognitionFullExample : MonoBehaviour
{
    // Instancias de los reconocedores
    private KeywordRecognizer keywordRecognizer;

    // Variable para almacenar el texto reconocido
    private string recognizedText = "";

    void Start()
    {
        // ------------------------ KeywordRecognizer ------------------------
        // Reconoce �nicamente palabras clave predefinidas
        string[] keywords = { "play", "stop", "pause", "avanzar", "hacia adelante", "vamos hacia adelante", "hacia atras", "vamos hacia atras" };
        keywordRecognizer = new KeywordRecognizer(keywords);
        keywordRecognizer.OnPhraseRecognized += OnKeywordRecognized;
        keywordRecognizer.Start(); // Inicia la detecci�n de palabras clave
    }

    // Callback del KeywordRecognizer
    private void OnKeywordRecognized(PhraseRecognizedEventArgs args)
    {
        // PhraseRecognizedEventArgs contiene informaci�n como el texto reconocido y el nivel de confianza
        Debug.Log("Keyword Recognized: " + args.text);
        Debug.Log("Confidence: " + args.confidence);
    }

    void OnDestroy()
    {
        // Se detienen y liberan los reconocedores si est�n en ejecuci�n
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
        }
    }
}
