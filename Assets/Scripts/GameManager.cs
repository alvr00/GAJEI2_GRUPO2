using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerGirlPrefab;
    [SerializeField] GameObject playerViejo;
    //Patrón Singleton
    public static GameManager gM;
    private void Awake()
    {
        if(gM == null)
        {
            gM = this;
        }
        else if(gM != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += EscenaCargada;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void EscenaCargada(Scene name, LoadSceneMode mode)
    {
        //if(name == "Menu")
        //{

        //}
        //else if(name == "Nivel2")
        //{
        //    G
        //}
    }

  
}
