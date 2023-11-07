using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public static Puntaje Instance;
    private float tiempoActual;
    private TextMeshProUGUI texto;

    public TextMeshProUGUI Texto { get => texto; set => texto = value; }

    private void Awake()
    {
        if (Puntaje.Instance == null)
        {
            Puntaje.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        tiempoActual = 30f;
        Texto = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        tiempoActual -= Time.deltaTime;
        Texto.text = tiempoActual.ToString("0");
    }

    public void SumarTiempo()
    {
        tiempoActual += 11f;
    }

    public void ResetPuntaje(){
        tiempoActual = 30f;
    }
}
