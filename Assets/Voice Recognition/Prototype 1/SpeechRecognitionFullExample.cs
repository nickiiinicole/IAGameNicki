using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;

/// <summary>
/// Ejemplo completo de reconocimiento de voz en Unity.
/// Demuestra el uso de:
/// - DictationRecognizer: para dictado continuo.
/// - KeywordRecognizer: para detectar palabras clave.
/// - GrammarRecognizer: para reconocer frases estructuradas con gramática y semántica.
/// - PhraseRecognitionSystem: para suscribirse a eventos globales del sistema de reconocimiento.
/// Además, se muestran ejemplos de cómo trabajar con PhraseRecognizedEventArgs y SemanticMeaning.
/// </summary>
public class SpeechRecognitionFullExample : MonoBehaviour
{
    // Instancias de los reconocedores
    //private DictationRecognizer dictationRecognizer;
    private KeywordRecognizer keywordRecognizer;
    //private GrammarRecognizer grammarRecognizer/*;*/

    // Variable para almacenar el texto reconocido por el dictado
    private string recognizedText = "";

    void Start()
    {
        // ------------------------ DictationRecognizer ------------------------
        // Este reconocedor convierte el discurso en texto en tiempo real.
        //dictationRecognizer = new DictationRecognizer();
        //dictationRecognizer.DictationResult += OnDictationResult;
        //dictationRecognizer.Start(); // Inicia el dictado

        // ------------------------ KeywordRecognizer ------------------------
        // Reconoce únicamente palabras clave predefinidas.
        string[] keywords = { "play", "stop", "pause" };
        keywordRecognizer = new KeywordRecognizer(keywords);
        keywordRecognizer.OnPhraseRecognized += OnKeywordRecognized;
        keywordRecognizer.Start(); // Inicia la detección de palabras clave

        // ------------------------ GrammarRecognizer ------------------------
        // Utiliza un archivo XML para definir reglas de reconocimiento con semántica.
        // El archivo 'GrammarWithSemantics.xml' debe ubicarse en la carpeta StreamingAssets.
        //grammarRecognizer = new GrammarRecognizer(Application.streamingAssetsPath + "/GrammarWithSemantics.xml");
        //grammarRecognizer.OnPhraseRecognized += OnGrammarRecognized;
        //grammarRecognizer.Start(); // Inicia el reconocimiento basado en gramática

        // ------------------------ PhraseRecognitionSystem ------------------------
        // Clase estática que envía eventos globales del sistema de reconocimiento.
        // Se suscribe a eventos de error y cambio de estado.
        PhraseRecognitionSystem.OnError += OnPhraseRecognitionSystemError;
        PhraseRecognitionSystem.OnStatusChanged += OnPhraseRecognitionSystemStatusChanged;
    }

    // Callback del DictationRecognizer
    private void OnDictationResult(string text, ConfidenceLevel confidence)
    {
        recognizedText = text;
        Debug.Log("Dictation Recognized: " + text);
    }

    // Callback del KeywordRecognizer
    private void OnKeywordRecognized(PhraseRecognizedEventArgs args)
    {
        // PhraseRecognizedEventArgs contiene información como el texto reconocido y el nivel de confianza.
        Debug.Log("Keyword Recognized: " + args.text);
        Debug.Log("Confidence: " + args.confidence);
    }

    // Callback del GrammarRecognizer, que también muestra el uso de SemanticMeaning.
    private void OnGrammarRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Grammar Recognized: " + args.text);
        // Si el XML de gramática define etiquetas semánticas, se pueden extraer a través de SemanticMeaning.
        foreach (SemanticMeaning meaning in args.semanticMeanings)
        {
            Debug.Log("Semantic Key: " + meaning.key);
            foreach (string value in meaning.values)
            {
                Debug.Log("Semantic Value: " + value);
            }
        }
    }

    // Callback de errores del PhraseRecognitionSystem (evento global)
    private void OnPhraseRecognitionSystemError(SpeechError errorCode)
    {
        Debug.Log("PhraseRecognitionSystem Error: " + errorCode);
    }

    // Callback para cambios de estado en el PhraseRecognitionSystem (evento global)
    private void OnPhraseRecognitionSystemStatusChanged(SpeechSystemStatus status)
    {
        Debug.Log("PhraseRecognitionSystem Status Changed: " + status);
    }

    void OnDestroy()
    {
        // Se detienen y liberan los reconocedores si están en ejecución.
        //if (dictationRecognizer != null && dictationRecognizer.Status == SpeechSystemStatus.Running)
        //{
        //    dictationRecognizer.Stop();
        //    dictationRecognizer.Dispose();
        //}
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
        }
        //if (grammarRecognizer != null && grammarRecognizer.IsRunning)
        //{
        //    grammarRecognizer.Stop();
        //    grammarRecognizer.Dispose();
        //}

        // Se desuscriben los eventos globales del PhraseRecognitionSystem.
        PhraseRecognitionSystem.OnError -= OnPhraseRecognitionSystemError;
        PhraseRecognitionSystem.OnStatusChanged -= OnPhraseRecognitionSystemStatusChanged;
    }
}
