using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    [SerializeField] Animator anims;
    [SerializeField] int vidas;
    // Start is called before the first frame update
    void Start()
    {
        anims.GetComponent<Animator>();
    }

    public void RestarVidasEnemigos(int cantidad)
    {
        vidas -= cantidad;
        if (vidas <= 0)
        {
            anims.SetTrigger("muerte");
            
        }
    }

    public void Desaparecer()
    {
        Destroy(gameObject);
    }
}
