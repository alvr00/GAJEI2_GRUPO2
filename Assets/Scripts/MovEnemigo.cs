using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour
{
    GameObject Player;
    bool puedeAtq;
    bool atacando;
    [SerializeField] GameObject disparo1Prefab;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float xPos = Mathf.Clamp(transform.position.x, -9.33f, 9.41f);
        float yPos = Mathf.Clamp(transform.position.y, -4.14f, 4.26f);
        transform.position = new Vector3(xPos, yPos, 0);

        if (Vector3.Distance(transform.position, Player.transform.position) < 9) //Rango de visión
        {
            if(!puedeAtq)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 4 * Time.deltaTime);
            }
            if (Vector3.Distance(transform.position, Player.transform.position) < 5 ) //Rango de ataque
            {
                puedeAtq = true;

                if(!atacando)
                    StartCoroutine(Disparo());
            }
            else
            {
                puedeAtq = false;
            }

        }
    }
    IEnumerator Disparo()
    {
        atacando = true;
        while (puedeAtq)
        {
            Instantiate(disparo1Prefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);

        }
        atacando = false;
        
    }
}
