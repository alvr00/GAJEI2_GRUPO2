using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boba : MonoBehaviour
{
    GameObject player;
    bool disparandoBas, disparandoMisil; 
    [SerializeField] GameObject disparoPrefab;
    SpriteRenderer sR;
    Animator anims;
    Rigidbody2D rb;
    [SerializeField] GameObject ondaPrefab;
    [SerializeField] GameObject misilPrefab;
    [SerializeField] LayerMask escenario;
    Coroutine disparoBasico, disparoMisil;
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

        Vector3 distanciaPlayer = player.transform.position - transform.position;
        float distaciaX = distanciaPlayer.x;
        if (distaciaX > 0)
        {
            sR.flipX = false;
        }
        else if (distaciaX < 0)
        {
            sR.flipX = true;
        }

        if (distAPlayer >= 7 && distAPlayer < 8.45f) //Rango de visión
        {
            StopAllCoroutines();
            disparandoBas = false;
            disparandoMisil = false;

            rb.velocity = new Vector2(5 * Mathf.Sign(distaciaX), rb.velocity.y);
            anims.SetBool("andando", true);


        }
        else if (distAPlayer >= 5 && distAPlayer < 7)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anims.SetBool("andando", false);
            if (!disparandoMisil)
            {
                if(disparoBasico != null)
                {
                    StopCoroutine(disparoBasico);
                }
                if(!disparandoMisil)
                {
                    disparoMisil = StartCoroutine(DisparoMisil());
                }
            }
        }
        else if (distAPlayer > 1 && distAPlayer < 5) //Rango de ataque
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anims.SetBool("andando", false);
            if (disparoMisil != null)
            {
                StopCoroutine(disparoMisil);
            }
            if (!disparandoBas)
            {
                disparoBasico = StartCoroutine(Disparo());
            }
        }
       
        else if (distAPlayer <= 1)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            StopAllCoroutines();
            disparandoBas = false;
            disparandoMisil = false;
            anims.SetBool("andando", false);

            anims.SetTrigger("golpeCerca");
        }
    }
    private void FixedUpdate() //0.02s
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 0.9f), 0.1f, escenario);
        if (colls.Length > 0)
        {
            anims.SetBool("volando", false);
        }
        else
        {
            anims.SetBool("volando", true);
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - 0.9f, 0), 0.1f);
    }

    IEnumerator Disparo()
    {
        disparandoBas = true;
        while (true)
        {
            if(Random.Range(0f, 100f) <= 30f) // 20%
            {
                Debug.Log("Salto");
                rb.AddForce(Vector2.up * Random.Range(5f, 7f), ForceMode2D.Impulse);
                anims.SetBool("volando",true);
            }
            else
            {
                anims.SetTrigger("disparo");
                DispararOnda();
            }
            yield return new WaitForSeconds(2f);
        }

    }
    IEnumerator DisparoMisil()
    {
        disparandoMisil = true;
        while (true)
        {
            if (Random.Range(0f, 100f) <= 30f) // 20%
            {
                Debug.Log("Salto");
                rb.AddForce(Vector2.up * Random.Range(7f, 10f), ForceMode2D.Impulse);
                anims.SetBool("volando",true);
            }
            else
            {
                anims.SetTrigger("disparoMisil");
                DispararMisil();
            }
            yield return new WaitForSeconds(3.5f);
        }


    }

    private void Clampear()
    {
        //float xPos = Mathf.Clamp(transform.position.x, -9.33f, 9.41f);
        //float yPos = Mathf.Clamp(transform.position.y, -4.14f, 4.26f);
        //transform.position = new Vector3(xPos, yPos, 0);
    }

    public void DispararOnda()
    {
        if (!sR.flipX)
        {
            GameObject ondaCopia = Instantiate(ondaPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            ondaCopia.GetComponent<OndaBoba>().direccionOnda = new Vector3(1, 0, 0);

        }
        else if (sR.flipX)
        {
            GameObject ondaCopia = Instantiate(ondaPrefab, transform.position + new Vector3(-1f, 0, 0), Quaternion.identity);
            ondaCopia.GetComponent<OndaBoba>().direccionOnda = new Vector3(-1, 0, 0);

        }
    }
    public void DispararMisil()
    {
        if (!sR.flipX)
        {
            GameObject misilCopia = Instantiate(misilPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            misilCopia.GetComponent<MIsilBoba>().direccionMisil = new Vector3(1, 0, 0);

        }
        else if (sR.flipX)
        {
            GameObject misilCopia = Instantiate(misilPrefab, transform.position + new Vector3(-1f, 0, 0), Quaternion.Euler(0, 180, 0));
            misilCopia.GetComponent<MIsilBoba>().direccionMisil = new Vector3(-1, 0, 0);

        }
    }


}

    

