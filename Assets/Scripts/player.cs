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
    [SerializeField] LayerMask escenario;
    [SerializeField] LayerMask enemigos;
    SpriteRenderer sR;
    Rigidbody2D rb;

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
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
                rb.AddForce(Vector2.up * 17, ForceMode2D.Impulse);
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
            Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position + new Vector3(sR.flipX ? -1 : 1, 0, 0), 0.5f, enemigos);
            if (colls.Length >= 0)
            {
                colls[0].gameObject.GetComponent<VidaEnemigos>().RestarVidasEnemigos(50);
            }
        }

    }
    /*private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + new Vector3(sR.flipX ? -1 : 1, 0, 0), 0.5f);
    }*/
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
