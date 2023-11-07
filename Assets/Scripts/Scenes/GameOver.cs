using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Start() {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = "Lo siento bro...";
        Puntaje.Instance.gameObject.SetActive(false);
    }
    public void BackToMainMenu(string levelName){
        SceneManager.LoadScene(levelName);
    }
}
