using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class VIctoria : MonoBehaviour
{
    [SerializeField] TMP_Text Texto_Victoria;
    void Start()
    {
        
    }
    void Update()
    {
        Texto_Victoria.text = "¡ENHORABUENA, HAS GANADO!, te has ganado una galleta";
    }
    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("FirstPerson");
        DynamicGI.UpdateEnvironment();

       
    }
}
