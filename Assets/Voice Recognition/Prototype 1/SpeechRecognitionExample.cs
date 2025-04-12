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

    // Callback cuando se reconoce una frase basada en gram�tica XML
    void OnGrammarRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Grammar Recognized: " + args.text);

        foreach (var semantic in args.semanticMeanings)
        {
            string key = semantic.key;
            string value = semantic.values[0];

            Debug.Log($"Sem�ntica reconocida - {key}: {value}");

            // Aqu� puedes mapear la acci�n seg�n la sem�ntica
            if (key == "action")
            {
                if (value == "move") Debug.Log("Acci�n: Mover");
                if (value == "shoot") Debug.Log("Acci�n: Disparar");
                if (value == "jump") Debug.Log("Acci�n: Saltar");
            }
            else if (key == "direction")
            {
                Debug.Log("Direcci�n: " + value);
            }
        }
    }

    void OnDestroy()
    {
        if (grammarRecognizer != null && grammarRecognizer.IsRunning)
            grammarRecognizer.Stop();
    }
}
