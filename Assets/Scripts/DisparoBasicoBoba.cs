using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBasicoBoba : MonoBehaviour
{
    GameObject Player;
    Vector3 direccionDisparo;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        direccionDisparo = (Player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(direccionDisparo.normalized * 4 * Time.deltaTime);
    }
}
