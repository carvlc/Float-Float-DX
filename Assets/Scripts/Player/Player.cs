using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private float limitRangeX;
    private bool isFacingRight;
    private float verticalForce;
    
    Rigidbody2D rb2d;
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        verticalForce = 800f;
        limitRangeX = 9f;
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
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
        rb2d.AddForce(transform.up * verticalForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingRight = !isFacingRight;
    }
}
