using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
  
  [SerializeField] TMP_Text Texto_Muerte;
    
    void Start()
    {
        
    }
    void Update()
    {
        Texto_Muerte.text = "Vaya, has muerto";
    }
    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("FirstPerson");
        DynamicGI.UpdateEnvironment();
    }
}
