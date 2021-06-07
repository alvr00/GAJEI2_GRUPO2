using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndaBoba : MonoBehaviour
{
  
    Vector3 direccionOnda;
    // Start is called before the first frame update
    void Start()
    {
        direccionOnda = new Vector3(1,0,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccionOnda.normalized * 10 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ZonaMuerte"))
        {
            Destroy(gameObject);
        }
    }
}
