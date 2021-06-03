using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class player : MonoBehaviour
{
    float velocidad = 8f;
    int h;
    [SerializeField] GameObject misilPrefab;
    [SerializeField] Animator anim;
    [SerializeField] GameObject sableVolandoPrefab;
    [SerializeField] LayerMask escenario;
    SpriteRenderer sR;
    Rigidbody2D rb;

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = (int)Input.GetAxisRaw("Horizontal");
        if(h == -1)
        {
            sR.flipX = true;
        }
        else if(h == 1)
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
                anim.SetBool("jumping", true);
            }
        }

        if(CheckGround().Length > 0 && rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("atacar" + Random.Range(0, 2));
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

    }

}
