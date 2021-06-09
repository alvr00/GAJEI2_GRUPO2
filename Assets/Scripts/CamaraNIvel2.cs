using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraNIvel2 : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 3f, -10);
        float yPos = Mathf.Clamp(transform.position.y, 0.45f, 0.92f);
        float xPos = Mathf.Clamp(transform.position.x, -4.51f, 39.38f);
        transform.position = new Vector3(xPos, yPos, -10);
    }
  
}
