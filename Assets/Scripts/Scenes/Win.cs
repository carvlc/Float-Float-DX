using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MejorTiempo : MonoBehaviour
{
    private string mejor;
    private TextMeshProUGUI textMesh;

    private void Start() {
        mejor = Puntaje.Instance.Texto.text;
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = "Mejor Tiempo: " + mejor;
        Puntaje.Instance.gameObject.SetActive(false);
        Puntaje.Instance.ResetPuntaje();
    }

    public void BackToMainMenu(string levelName){
        SceneManager.LoadScene(levelName);
    }
}
