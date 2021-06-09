using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldadoEscopeta : MonoBehaviour
{
    GameObject player;
    bool estaatacando = false;
    SpriteRenderer sR;
    Animator anims;
    Rigidbody2D rb;
    int danioSoldado = 20;
    [SerializeField] LayerMask capaPlayer;
    // Start is called before the first frame update
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
        float distAPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distAPlayer >= 3 && distAPlayer < 9) //Rango de visión
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

        else if (distAPlayer > 1 && distAPlayer < 3) //Rango de ataque
        {
            anims.SetBool("andando", false);
            if(!estaatacando)
                StartCoroutine(Disparo());
        }
    }
    IEnumerator Disparo()
    {
        estaatacando = true;

        while (true)
        {
            anims.SetTrigger("disparo");
            Vector3 dirAPlayer = (player.transform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dirAPlayer, 2.5f, capaPlayer);
            if (hit.collider != null)
            {
                VidaYDanio scr = hit.transform.GetComponent<VidaYDanio>();
                scr.RestarVidas(danioSoldado);
                Debug.Log("au");
            }
            yield return new WaitForSeconds(2f);
        }

    }
}
