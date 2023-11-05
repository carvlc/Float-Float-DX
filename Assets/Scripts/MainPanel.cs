using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainPanel : MonoBehaviour
{
    [Header("Options")]
    public Slider volumeFx;
    public Slider volumeMaster;
    public Toggle mute;
    public AudioSource fxSource;
    public AudioClip clipSound;
    public AudioMixer mixer;
    private float lastVolume;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelSelectPanel;

    private void Awake() {
        volumeFx.onValueChanged.AddListener(ChangeVolumeFX); // cuando cambia el valor del slider llama a la funcion 
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }
    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }

    public void ChangeVolumeMaster(float valor)
    {
        mixer.SetFloat("VolMaster", valor);
    }
    public void ChangeVolumeFX(float valor)
    {
        mixer.SetFloat("VolFX", valor);
    }

    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clipSound);
    }

    public void setMute()
    {
        if (mute.isOn)
        {
        mixer.GetFloat("VolMaster", out lastVolume);

            mixer.SetFloat("VolMaster", -80);
        }
        else 
        {
            mixer.SetFloat("VolMaster", lastVolume);
        }
    }

    public void PlayLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
