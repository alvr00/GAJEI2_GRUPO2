using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorDeNiveles : MonoBehaviour
{
    public void CargarSiguienteNivel() 
    {
      int escenaActual =  SceneManager.GetActiveScene().buildIndex;
      int siguienteEscena = escenaActual + 1;
      SceneManager.LoadScene(siguienteEscena);


    
    
    }
}
