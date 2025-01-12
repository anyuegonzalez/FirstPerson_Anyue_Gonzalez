using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using TMPro;

public class EmpezarJuego : MonoBehaviour
{

    [SerializeField] TMP_Text Texto_Comenzar;
    void Start()
    {
        
    }

   
    void Update()
    {
        Texto_Comenzar.text = "Bienvenido.";
    }
    public void Comenzar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("FirstPerson");
        DynamicGI.UpdateEnvironment();


    }
}
