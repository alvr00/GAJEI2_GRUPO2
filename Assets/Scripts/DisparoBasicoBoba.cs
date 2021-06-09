using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBasicoBoba : MonoBehaviour
{
    GameObject Player;
    int cantidadDanio = 10;
    Vector3 direccionDisparo;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        direccionDisparo = (Player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(direccionDisparo.normalized * 8 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<VidaYDanio>().RestarVidas(cantidadDanio);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Findisparos"))
        {
            Destroy(gameObject);
        }
    }

}
