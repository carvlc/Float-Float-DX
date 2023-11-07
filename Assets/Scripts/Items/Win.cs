using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MejorTiempo : MonoBehaviour
{
    private string mejor;
    private TextMeshProUGUI textMesh;

    private void Start() {
        mejor = Puntaje.Instance.Texto.text;
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = "Mejor Tiempo: " + mejor;
        Puntaje.Instance.gameObject.SetActive(false);
    }
}
