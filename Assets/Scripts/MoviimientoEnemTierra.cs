using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviimientoEnemTierra : MonoBehaviour
{
    //Rigidbody dinámico con gravedad.
    Rigidbody2D rb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        Vector2 distancia = player.transform.position - transform.position;
        if(distancia.x < 0)
        {
            rb.velocity = new Vector2(-1*5, rb.velocity.y);

        }
        else if(distancia.x > 0)
        {
            rb.velocity = new Vector2(1*5, rb.velocity.y);
        }
    }
}
