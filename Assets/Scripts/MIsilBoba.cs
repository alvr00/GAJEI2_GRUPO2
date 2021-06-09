using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIsilBoba : MonoBehaviour
{
    [HideInInspector] public Vector3 direccionMisil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccionMisil.normalized * 10 * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ZonaMuerte"))
        {
            Destroy(gameObject);
        }
    }
}
