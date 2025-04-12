using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;

public class SpeechRecognitionExample : MonoBehaviour
{
    private GrammarRecognizer grammarRecognizer;
    private string recognizedText = "";

    void Start()
    {
        
        string grammarPath = System.IO.Path.Combine(Application.streamingAssetsPath, "GrammarWithSemantics.xml");
        grammarRecognizer = new GrammarRecognizer(grammarPath);
        grammarRecognizer.OnPhraseRecognized += OnGrammarRecognized;
        grammarRecognizer.Start();

        Debug.Log("GrammarRecognizer iniciado con: " + grammarPath);
    }

    // Callback cuando se reconoce una frase basada en gramática XML
    void OnGrammarRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Grammar Recognized: " + args.text);

        foreach (var semantic in args.semanticMeanings)
        {
            string key = semantic.key;
            string value = semantic.values[0];

            Debug.Log($"Semántica reconocida - {key}: {value}");

            // Aquí puedes mapear la acción según la semántica
            if (key == "action")
            {
                if (value == "move") Debug.Log("Acción: Mover");
                if (value == "shoot") Debug.Log("Acción: Disparar");
                if (value == "jump") Debug.Log("Acción: Saltar");
            }
            else if (key == "direction")
            {
                Debug.Log("Dirección: " + value);
            }
        }
    }

    void OnDestroy()
    {
        if (grammarRecognizer != null && grammarRecognizer.IsRunning)
            grammarRecognizer.Stop();
    }
}
