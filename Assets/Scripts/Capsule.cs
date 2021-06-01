using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private Collider2D micolisionador;
    [SerializeField] GestorDeNiveles miGestorDeNiveles;
    // Start is called before the first frame update
    void Start()
    {
        micolisionador = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        miGestorDeNiveles.CargarSiguienteNivel();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
