using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] static ScoreManager instance;
    [SerializeField] int puntuacion = 0;

    [SerializeField] TMP_Text Texto_puntuacion;

    public static ScoreManager Instance { get => instance; set => instance = value; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddPoints(int puntos)
    {
        puntuacion += puntos;
    }
    void Start()
    {
        
    }

    void Update()
    {
        Texto_puntuacion.text = "Puntos:; " + puntuacion;
    }
}
