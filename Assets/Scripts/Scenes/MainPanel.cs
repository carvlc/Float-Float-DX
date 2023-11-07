using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainPanel : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject levelSelectPanel;

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        panel.SetActive(true);
    }
   
    public void PlayLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }

}
