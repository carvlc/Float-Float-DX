using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeEnemy : MonoBehaviour
{

    private float speed;
    private Vector3[] posiciones;
    void Start()
    {
        speed = 1f;
        ObtenerPutosPosicion();
        StartCoroutine("CorrutinaAbeja");
    }


    IEnumerator CorrutinaAbeja()
    {
        int i = 1;
        Vector3 nuevaPosicion = new Vector3(transform.position.x, posiciones[i].y, 0);

        while (true)
        {
            while (transform.position != nuevaPosicion)
            {
                transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, speed * Time.deltaTime);
                yield return null;
            }
            if (i < 1)
            {
                i++;
            }
            else{
                i = 0;
            }
            nuevaPosicion = new Vector3(transform.position.x, posiciones[i].y, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damage by Bee");
            Destroy(collision.gameObject);
        }
    }

    private void ObtenerPutosPosicion()
    {
        posiciones = new Vector3[2];
        posiciones[0] = transform.position;
        posiciones[1] = new Vector3(transform.position.x, transform.position.y - 2, 0);
    }
}