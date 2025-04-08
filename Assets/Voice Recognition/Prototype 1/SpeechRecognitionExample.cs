using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SpeechRecognitionExample : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    //private GrammarRecognizer grammarRecognizer;
    private string recognizedText = "";

    void Start()
    {
        // DictationRecognizer: permite el reconocimiento continuo del habla,
        // convirtiendo el discurso en texto en tiempo real.
        //    dictationRecognizer = new DictationRecognizer();
        //    dictationRecognizer.DictationResult += (text, confidence) =>
        //    {
        //        recognizedText = text;
        //        Debug.Log("DEFAULT Recognized: " + text);
        //    };
        //    dictationRecognizer.Start(); // Inicia el reconocimiento de dictado

        // KeywordRecognizer: reconoce palabras clave específicas predefinidas.
        // Solo detecta palabras exactas en la lista y no frases completas.
        string[] keywords = { "start", "stop", "pause" };
        keywordRecognizer = new KeywordRecognizer(keywords);
        keywordRecognizer.OnPhraseRecognized += OnKeywordRecognized;
        keywordRecognizer.Start(); // Inicia el reconocimiento de palabras clave

        // GrammarRecognizer: usa un archivo XML para definir reglas de reconocimiento de frases estructuradas.
        // Se emplea para entender comandos más complejos en base a una gramática predefinida.
        //grammarRecognizer = new GrammarRecognizer(Application.streamingAssetsPath + "/Grammar.xml");
        //grammarRecognizer.OnPhraseRecognized += OnGrammarRecognized;
        //grammarRecognizer.Start(); // Inicia el reconocimiento basado en gramática
    }

    // Callback cuando se reconoce una palabra clave
    void OnKeywordRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword Recognized: " + args.text);
    }

    // Callback cuando se reconoce una frase basada en gramática XML
    void OnGrammarRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Grammar Recognized: " + args.text);
    }

    void OnDestroy()
    {
        // Asegura que se detienen los reconocedores cuando el objeto es destruido
        //if (dictationRecognizer != null && dictationRecognizer.Status == SpeechSystemStatus.Running)
        //    dictationRecognizer.Stop();
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
           keywordRecognizer.Stop();
        //if (grammarRecognizer != null && grammarRecognizer.IsRunning)
        //    grammarRecognizer.Stop();
    }
}
