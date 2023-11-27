using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] List<string> frases = new List<string>();
    Canvas _canvas;
    TextMeshProUGUI _text;
    [SerializeField] int contador = 0;

    private void Start()
    {
        _canvas = GetComponentInChildren<Canvas>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _canvas.enabled = false;
        _text.enabled = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (contador < frases.Count-1) contador++;
            else contador = 0;

            _text.text = frases[contador];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.enabled = true;
            _text.enabled = true;
            contador = 0;
            _text.text = frases[0];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _canvas.enabled = false;
        _text.enabled = false;
    }


}
