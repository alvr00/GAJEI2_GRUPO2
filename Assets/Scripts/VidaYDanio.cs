using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaYDanio : MonoBehaviour
{
    [SerializeField] int vidas = 100;

    public void RestarVidas(int conatidad)
    {
        vidas -= 20;
    }
}
