using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float velocidad = 8f;
    [SerializeField] GameObject misilPrefab;
    [SerializeField] Animator anim;
    
    

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
            anim.SetTrigger("jump");

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("misilBoba1"))
        {
            Destroy(collision.gameObject);
        }
    }
}
