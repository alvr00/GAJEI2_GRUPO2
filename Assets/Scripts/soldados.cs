using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldados : MonoBehaviour
{
    GameObject player;
    bool estaatacando;
    [SerializeField] GameObject disparoPrefab;
    SpriteRenderer sR;
    Animator anims;
    Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sR = GetComponent<SpriteRenderer>();
        anims = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Clampear();
        float distanciaRandom = Random.Range(4f, 7f);
        float distAPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distAPlayer >= 5 && distAPlayer < 9) //Rango de visión
        {
            StopAllCoroutines();
            estaatacando = false;

            Vector3 distanciaPlayer = player.transform.position - transform.position;
            float distaciaX = distanciaPlayer.x;
                
            rb.velocity = new Vector2(5 * Mathf.Sign(distaciaX), rb.velocity.y);
            anims.SetBool("andando", true);
            if (distaciaX > 0)
            {
                sR.flipX = false;
            }
            else if (distaciaX < 0)
            {
                sR.flipX = true;
            }
           

        }
        else if (distAPlayer > 2 && distAPlayer < distanciaRandom) //Rango de ataque
        {
            anims.SetBool("andando", true);
            if (!estaatacando)
                StartCoroutine(Disparo());
        }
        else if (distAPlayer <= 2)
        {
            StopAllCoroutines();
            estaatacando = false;
            anims.SetBool("andando", false);

            anims.SetTrigger("melee");
        }
        

        IEnumerator Disparo()
        {
            estaatacando = true;

            while (true)
            {
                anims.SetTrigger("disparo");
                Disparar();
                yield return new WaitForSeconds(2f);

            }

        }

    }

    private void Clampear()
    {
        //float xPos = Mathf.Clamp(transform.position.x, -9.33f, 9.41f);
        //float yPos = Mathf.Clamp(transform.position.y, -4.14f, 4.26f);
        //transform.position = new Vector3(xPos, yPos, 0);
    }

    public void Disparar()
    {
        Instantiate(disparoPrefab, transform.position + new Vector3 (-0.47f, 0.28f, 0), Quaternion.identity);
    }
}
