using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Selection(int index) 
    {
        GameManager.gM.playerPrefab = this.prefabs[index];

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
