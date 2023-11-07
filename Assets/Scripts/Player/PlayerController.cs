using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // se declara un atributo player
    private Player player;
    [SerializeField] AudioClip jumpSFX;
    // Start is called before the first frame update
    void Start()
    {
        // inicializa el objeto player
        player = GetComponent<Player>();// se obtiene el componente player de este gameobject
        Puntaje.Instance.gameObject.SetActive(true);// se muestra el puntaje
        Puntaje.Instance.ResetPuntaje();//se resetea el puntaje
    }

    // Update is called once per frame
    void Update()
    {
        CaptureInput();
    }

    public void CaptureInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        player.Move(horizontalInput);

        if (Input.GetButtonDown("Jump"))
        {
            SoundJump.Instance.PlaySoundJump(jumpSFX);
            player.FloatFloat();
        }
    }
}
