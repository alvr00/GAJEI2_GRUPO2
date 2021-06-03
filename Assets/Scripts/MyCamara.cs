using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamara : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void Start()
    {
        
    }
    private void Update()
    {
    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 3f, -10);
        float yPos = Mathf.Clamp(transform.position.y, 0.67f, 1.85f);
        transform.position = new Vector3(transform.position.x, yPos, -10);
    }
}
