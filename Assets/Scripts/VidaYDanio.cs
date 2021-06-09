using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaYDanio : MonoBehaviour
{
    [SerializeField] int vidas;
    [SerializeField] Animator playerAnims;
    [SerializeField] GameObject derrota;
  
 

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
            derrota.SetActive(true);
            Destroy(gameObject);
       
        }
     
    }
}
