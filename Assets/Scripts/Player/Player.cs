using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.VisualScripting;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private float limitRangeX;
    private bool isFacingRight;
    private float verticalForce;
    
    Rigidbody2D rb2d;
    private PhotonView photonView;
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        verticalForce = 6f;
        limitRangeX = 9f;
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float movementX = Input.GetAxis("Horizontal");
        if (movementX > 0 && isFacingRight)
        {
            Flip();
        }
        else if (movementX < 0 && !isFacingRight)
        {
            Flip();
        }
        }
        
    }
    public void Move(float horizontalInput)
    {
        // control para que el player no se salga de la pantalla en los laterales
        if (gameObject.transform.position.x < -limitRangeX)
        {
            gameObject.transform.position = new Vector3(-limitRangeX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (transform.position.x > limitRangeX)
        {
            transform.position = new Vector3(limitRangeX, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        }
    }

    public void FloatFloat()
    {
        rb2d.AddForce(transform.up * verticalForce, ForceMode2D.Impulse);
    }

    public void Flip()
    {
        if (photonView.IsMine)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingRight = !isFacingRight;
        }
        photonView.RPC("SyncFlip", RpcTarget.Others, isFacingRight);
        
    }
    //Este método se ejecuta en los demás jugadores (RpcTarget.Others) y sincroniza la dirección de la escala local del jugador con el valor del jugador local.
    [PunRPC]
    void SyncFlip(bool facingRight)
    {
        transform.localScale = new Vector3(facingRight ? 1 : -1, transform.localScale.y, transform.localScale.z);
        isFacingRight = facingRight;
    }
}
