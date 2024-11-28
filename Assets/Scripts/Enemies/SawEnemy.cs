using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamegeEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damage");
            
            if (collision.gameObject.GetComponent<PhotonView>().IsMine)
            {
                PhotonNetwork.Destroy(collision.gameObject); 
            }

            // cuando muere se desconecta del photonNetwork
            PhotonNetwork.Disconnect();

            SceneManager.LoadScene("GameOver");

        }
    }
}
