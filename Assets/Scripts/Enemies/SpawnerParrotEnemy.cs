using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpawnerParrotEnemy : MonoBehaviour
{
    private float speed;
    private Vector3[] posiciones;
    private ParrotEnemy parrot;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        ObtenerPutosPosicion();
        StartCoroutine("CorrutinaMoverNido");
        StartCoroutine("CorrutinaLoros");
    }

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
            else{
                i = 0;
            }
            nuevaPosicion = new Vector3(transform.position.x, posiciones[i].y, 0);
        }
    }
    IEnumerator CorrutinaLoros(){
        CreateParrot();
        yield return new WaitForSeconds(3);
        CreateParrot();
        yield return new WaitForSeconds(7);
        StartCoroutine("CorrutinaLoros");
    }
    public void CreateParrot(){
        Instantiate(Resources.Load("Parrot"), transform.position,Quaternion.identity);
    }

    private void ObtenerPutosPosicion()
    {
        posiciones = new Vector3[2];
        posiciones[0] = transform.position;
        posiciones[1] = new Vector3(transform.position.x, transform.position.y - 6, 0);
    }
}
