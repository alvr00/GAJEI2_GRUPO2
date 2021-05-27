using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGirl : MonoBehaviour
{

    float velocidad = 8f;
    int h;
    [SerializeField] GameObject misilPrefab;
    [SerializeField] Animator anim;
    [SerializeField] GameObject sableVolandoPrefab;
    [SerializeField] LayerMask escenario;
    SpriteRenderer sR;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = (int)Input.GetAxisRaw("Horizontal"); //-1,011
        if (h == -1)
        {
            sR.flipX = true;
        }
        else if (h == 1)
        {
            sR.flipX = false;
        }
        rb.velocity = new Vector2(h * velocidad, rb.velocity.y);
        anim.SetInteger("h", h);

        



        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (CheckGround().Length > 0)
            {
                rb.AddForce(Vector2.up * 13, ForceMode2D.Impulse);
                anim.SetTrigger("salto");
            }
           


        }
        if(rb.velocity.y < 0) //Estoy cayendo SIN tocar suelo.
        {
            if(CheckGround().Length == 0)
            {
                anim.SetBool("cayendo", true);
            }
            else
            {
                anim.SetBool("cayendo", false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("atacar" );
        }

        if (Input.GetMouseButtonDown(1))
        {
          
              anim.SetTrigger("lanzarEspada");
           
        }
        if (h != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("velocidad", true);
            velocidad = 20f;
        }
        if (h==0)
        {
            anim.SetBool("velocidad", false);
            velocidad = 8f;
        }
       
        if (Input.GetKey(KeyCode.F))
        {
            anim.SetBool("bloqueando", true);


        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            anim.SetBool("bloqueando", false);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y - 0.7f), 0.2f);
    }
    Collider2D[] CheckGround()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 0.7f), 0.2f, escenario);
        return colls;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("misilBoba1"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Disparo"))
        {
            if(anim.GetBool("bloqueando"))
            {
                Destroy(collision.gameObject);

            }
        }
    }
    void LanzarSable()
    {
        if (!sR.flipX)
        {
            GameObject sableCopia = Instantiate(sableVolandoPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            sableCopia.GetComponent<Sable>().objetivo = transform.position + new Vector3(5, 0, 0);

        }
        else if (sR.flipX)
        {
            GameObject sableCopia = Instantiate(sableVolandoPrefab, transform.position + new Vector3(-1f, 0, 0), Quaternion.identity);
            sableCopia.GetComponent<Sable>().objetivo = transform.position + new Vector3(-5, 0, 0);

        }
    }
}

