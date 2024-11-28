using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
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
        Puntaje.Instance.ResetPuntaje();
    }
    public void BackToMainMenu(string levelName){

        PhotonNetwork.Disconnect();// cuando muere se desctonecta de photon
        SceneManager.LoadScene(levelName);
    }
}
