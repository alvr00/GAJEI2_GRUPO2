using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] GameObject playerGirlPrefab;
    //[SerializeField] GameObject playerViejo;
    [HideInInspector] public GameObject playerPrefab;
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
        
    }

    void EscenaCargada(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 1)
        {
            Instantiate(playerPrefab, new Vector3(-7.53f, -3.5f, 0), Quaternion.identity);
        }
        if (scene.name.Equals("Nivel2"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(-5.38f,-3.10f,0);
        }
    }

    //public void BoySelected()
    //{
    //    player = playerViejo;
    //}
    //public void GirlSelected()
    //{
    //    player = playerGirlPrefab;
    //}

  
}
