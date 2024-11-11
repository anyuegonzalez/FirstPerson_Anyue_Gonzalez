using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    [SerializeField] private Enemigo mainScript; // script principal del enemigo
    [SerializeField] private float multiplicadorDanho;
    public void RecibirDanho(float danhoRecibido)
    {
        mainScript.Vidas -= (danhoRecibido * multiplicadorDanho);

        if (mainScript.Vidas <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
