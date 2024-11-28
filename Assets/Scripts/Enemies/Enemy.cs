using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed; // Atributo común entre enemigos

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damage");
            Destroy(collision.gameObject);
            SceneManager.LoadScene("GameOver");

        }
    }
}
