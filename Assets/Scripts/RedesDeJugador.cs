using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RedesDeJugador : MonoBehaviour
{
    public MonoBehaviour[] codigoQueIgnorar;

    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            foreach (var codigo in codigoQueIgnorar)
            {
                codigo.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
