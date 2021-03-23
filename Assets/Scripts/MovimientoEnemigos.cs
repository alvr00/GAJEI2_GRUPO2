using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 direccion;
    [SerializeField] float velocidad;
    Rigidbody2D rb;
    [SerializeField] float Fuerza;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        direccion = new Vector3(h, v, 0);
        transform.Translate(velocidad * direccion * Time.deltaTime, Space.World);
        

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1, 0) * Fuerza, ForceMode2D.Impulse);
        }
    }
}
