using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (photonView.IsMine)
        {
            animator.SetBool("isFloatFloat", false);
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (photonView.IsMine)
        {
animator.SetBool("isFloatFloat", true);
        }
        
    }
}
