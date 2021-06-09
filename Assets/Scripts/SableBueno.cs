using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SableBueno : MonoBehaviour
{

    public Vector3 objetivo;
    GameObject player;
    SpriteRenderer sR;
    [SerializeField] LayerMask enemigos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != objetivo)
        {

            transform.position = Vector3.MoveTowards(transform.position, objetivo, 12 * Time.deltaTime);
        }
        else
        {
            objetivo = player.transform.position;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("enemigos"))
        {
            Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position + new Vector3(sR.flipX ? -1 : 1, 0, 0), 0.5f, enemigos);
            if (colls.Length >= 0)
            {
                colls[0].gameObject.GetComponent<VidaEnemigos>().RestarVidasEnemigos(50);
            }
        }
    }


}
