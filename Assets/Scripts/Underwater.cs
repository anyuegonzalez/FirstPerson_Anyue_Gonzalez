using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour
{
    [SerializeField] float underwaterLevel = 7f;

    [SerializeField] Camera targetCamera;


    // defaultFog: Guarda si la niebla (RenderSettings.fog) estaba activada por defecto.
    // defaultFogColor: Almacena el color original de la niebla.
    // defaultFogDensity: Guarda la densidad original de la niebla.

    // Variables para guardar las configuraciones por defecto
    private bool defaultFog;
    private Color defaultFogColor;
    private float defaultFogDensity;


    void Start()
    {
        // Guardar las configuraciones por defecto
        defaultFog = RenderSettings.fog;
        defaultFogColor = RenderSettings.fogColor;
        defaultFogDensity = RenderSettings.fogDensity;

        // Establecer el color de fondo de la cámara
        targetCamera.backgroundColor = new Color(0, 0.4f, 0.7f, 1f);
    }

    void Update()
    {
        if (transform.position.y < underwaterLevel)
        {
            // Configuraciones bajo el agua para que cambie el color a azul cuando se sumerja por debajo de lo establecido
            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0, 0.4f, 0.7f, 0.6f);
            RenderSettings.fogDensity = 0.04f;
            
        }
        else
        {
            // Restaurar las configuraciones por defecto para cuando sales del agua
            RenderSettings.fog = defaultFog;
            RenderSettings.fogColor = defaultFogColor;
            RenderSettings.fogDensity = defaultFogDensity;
        }
    }
}
