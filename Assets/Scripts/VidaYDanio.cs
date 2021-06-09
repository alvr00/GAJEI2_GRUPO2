using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaYDanio : MonoBehaviour
{
    [SerializeField] int vidas = 100;
    [SerializeField] Animator playerAnims;

    private void Start()
    {
        playerAnims = GetComponent<Animator>();
    }
    public void RestarVidas(int cantidad)
    {
        vidas -= cantidad ;
        if (vidas <= 0)
        {
            playerAnims.SetTrigger("muerte");
            
        }
    }
}
