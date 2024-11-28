using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeEnemy : MonoBehaviourPunCallbacks, IPunObservable
{

    private float speed;
    private Vector3[] posiciones;

    private Vector3 posicioneSinc; // para mantener la posicion sincronizada

    void Start()
    {
        speed = 1f;
        ObtenerPutosPosicion();
        StartCoroutine("CorrutinaAbeja");

    }

    // Sincroniza las posiciones de las abejas entre todos los jugadores
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Enviamos nuestra posición a todos los clientes
            stream.SendNext(transform.position);
        }
        else
        {
            // Recibimos la posición de la abeja desde otro cliente
            posicioneSinc = (Vector3)stream.ReceiveNext();
        }
    }
    IEnumerator CorrutinaAbeja()
    {
        int i = 1;
        Vector3 nuevaPosicion = new Vector3(transform.position.x, posiciones[i].y, 0);

        while (true)
        {
            while (transform.position != nuevaPosicion)
            {
                if (photonView.IsMine)// para que solo el anfitrion pueda mover la aveja
                {
                    transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, speed * Time.deltaTime);
                }
                
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
            //Destroy(collision.gameObject);
            PhotonNetwork.Destroy(collision.gameObject);  // Usamos PhotonNetwork.Destroy para destruir al jugador en la red
            SceneManager.LoadScene("GameOver");
        }
    }

    private void ObtenerPutosPosicion()
    {
        posiciones = new Vector3[2];
        posiciones[0] = transform.position;
        posiciones[1] = new Vector3(transform.position.x, transform.position.y - 2, 0);
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            // Si no es nuestro objeto, actualizamos la posición sincronizada
            transform.position = Vector3.Lerp(transform.position, posicioneSinc, Time.deltaTime * 5f);
        }
    }
}