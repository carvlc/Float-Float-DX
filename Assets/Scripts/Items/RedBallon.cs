using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;// se desactiva el globo para poner animacion de explosion
            //reproducir sonido
            
            // se busca el bojeto padre mediante su script y se usa el metodo que controla si hay hijos (ballons) en el nivel
            FindObjectOfType<RedBallonManager>().AllBallonsCollected();
            Destroy(gameObject, 1f);//eliminar el objeto
        }
    }
}
