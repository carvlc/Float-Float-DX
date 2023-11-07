using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpawnerParrotEnemy : MonoBehaviour
{

    private float speed;// velocidad de movimiento del spawner
    private Vector3[] posiciones;// posiciones que marcan el rango de movimiento del Spawner 
    private ParrotEnemy parrot;//objeto parrot

    private float tiempoEspera;// tiempo espera para InvokeRepeating
    private float tiempoIntervalo; // tiempo intervalo para InvokeRepeating

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;//velocidad de movimiento del spawner en 1
        ObtenerPutosPosicion();// se obtiene la posicino actual del spawner
        StartCoroutine("CorrutinaMoverNido");//corrutina para el movimiento del generador de parrots

        tiempoEspera = 1f;
        tiempoIntervalo = 4f;
        InvokeRepeating("CreateParrot", tiempoEspera, tiempoIntervalo);// metodo InvokeRepeating para generar Parrots cada 4seg
    }

    // corrutina para el movimiento en dos puntos del spawner de parrots
    IEnumerator CorrutinaMoverNido()
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
            else
            {
                i = 0;
            }
            nuevaPosicion = new Vector3(transform.position.x, posiciones[i].y, 0);
        }
    }
    // metodo crea GameObjects de parrot
    public void CreateParrot()
    {
        Instantiate(Resources.Load("Parrot"), transform.position, Quaternion.identity);
    }
    // metodo obtiene las posicinoes que se usan para el desplazamiento del spawner
    private void ObtenerPutosPosicion()
    {
        posiciones = new Vector3[2];
        posiciones[0] = transform.position;
        posiciones[1] = new Vector3(transform.position.x, transform.position.y - 6, 0);
    }
}
