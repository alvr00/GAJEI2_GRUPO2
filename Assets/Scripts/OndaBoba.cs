using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndaBoba : MonoBehaviour
{
    int cantidadDanio = 25;
    [HideInInspector] public Vector3 direccionOnda;
    // Start is called before the first frame update
    void Start()
    {
        Boba scr = gameObject.GetComponent<Boba>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccionOnda.normalized * 5 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ZonaMuerte"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<VidaYDanio>().RestarVidas(cantidadDanio);
            Destroy(gameObject);
        }
    }
}
