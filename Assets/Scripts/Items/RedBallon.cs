using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;// se desactiva el globo
            //reproducir sonido
            Destroy(gameObject, 1f);//eliminar el objeto
        }
    }
}
