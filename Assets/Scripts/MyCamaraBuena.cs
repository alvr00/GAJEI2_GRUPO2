using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamaraBuena : MonoBehaviour
{
    GameObject player;
    
    private void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 3f, -10);
        float yPos = Mathf.Clamp(transform.position.y, 0.67f, 1.85f);
        float xPos = Mathf.Clamp(transform.position.x, -20.64f, 141.69f);
        transform.position = new Vector3(xPos, yPos, -10);
    }

  
}
