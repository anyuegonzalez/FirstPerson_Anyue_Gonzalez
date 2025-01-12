using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TMP_Text Texto_Muerte;
    private void Update()
    {
        Texto_Muerte.text = "Has muerto";
    }
    public void Reintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstPerson");
    }

}

