using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunicion : MonoBehaviour
{

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        
    }
    public void Abrir()
    {
        anim.SetTrigger("abrir");
    }
}
