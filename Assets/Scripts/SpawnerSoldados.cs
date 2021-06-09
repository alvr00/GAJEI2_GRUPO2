using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSoldados : MonoBehaviour
{
    int soldados = 4;
    int oleadas = 10;
    [SerializeField] GameObject[] soldadosEnemi;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstanciarSoldados());
    }
    IEnumerator InstanciarSoldados()
    {
        for (int i = 0; i < oleadas; i++)
        {
            for (int j = 0; j < soldados; j++)
            {
                Instantiate(soldadosEnemi[Random.Range(0, soldadosEnemi.Length)],transform.position, Quaternion.identity);
                yield return new WaitForSeconds(15f);
            }
        }
    }
    
}
