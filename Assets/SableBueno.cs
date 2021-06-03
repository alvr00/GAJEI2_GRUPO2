using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SableBueno : MonoBehaviour
{

    public Vector3 objetivo;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
    }
}
