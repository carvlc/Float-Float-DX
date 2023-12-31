using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallon : MonoBehaviour
{

    [SerializeField] private AudioClip ballonSFX;
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundBallon.Instance.PlaySoundBallon(ballonSFX);
            Puntaje.Instance.SumarTiempo();
            // se busca el bojeto padre mediante su script y se usa el metodo que controla si hay hijos (ballons) en el nivel
            FindObjectOfType<RedBallonManager>().AllBallonsCollected();
            Destroy(gameObject);//eliminar el objeto
        }
    }
}
