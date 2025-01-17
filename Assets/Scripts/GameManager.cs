using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject canvasPausa;
    [SerializeField] static int nivelJuego = 0;

    private FirstPerson jugador;
    private bool estaMuerto = false;

    [SerializeField] int puntosObjetivo = 25;
    public FirstPerson player;
    void Start()
    {
        canvasPausa.SetActive(false);
    }
    void Update()
    {
        if (ScoreManager.Instance != null && ScoreManager.Instance.Puntuacion >= puntosObjetivo)
        {
            SceneManager.LoadScene("Victoria");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvasPausa.activeSelf)
            {
                canvasPausa.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                canvasPausa.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void Continuar()
    {
        canvasPausa.SetActive(false);
        Time.timeScale = 1;
    }
    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Salir()
    {
        print("cerrando...");
        Application.Quit();
    }

}
