using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGirl : MonoBehaviour
{

    float velocidad = 8f;
    [SerializeField] GameObject misilPrefab;
    [SerializeField] Animator anim;
    [SerializeField] GameObject sableVolandoPrefab;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Input.GetAxisRaw("Horizontal");

        transform.Translate(new Vector3(xPos, 0, 0).normalized * velocidad * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            anim.SetTrigger("saltar");

        }
        if (Input.GetMouseButtonDown(1))
        {
            LanzarSable();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("misilBoba1"))
        {
            Destroy(collision.gameObject);
        }
    }
    void LanzarSable()
    {
        Instantiate(sableVolandoPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
    }
}
