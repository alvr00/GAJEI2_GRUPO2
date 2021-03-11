using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
