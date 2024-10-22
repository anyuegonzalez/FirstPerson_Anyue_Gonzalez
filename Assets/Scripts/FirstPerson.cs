using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;

    CharacterController controller;
    private Camera cam;
    void Start()
    {
        // bloquea el raton en el centro de la pantalla y lo oculta
        Cursor.lockState = CursorLockMode.Locked;
       controller = GetComponent<CharacterController>();

        cam = Camera.main;
    }

    
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        float v = Input.GetAxisRaw("Vertical");


        //Vector3 movimiento = new Vector3(h, 0, v ).normalized;
        
        Vector2 input = new Vector2(h, v).normalized;

        // si existe input...
        // sqrMagnitude es mas optimo que magnitude
        if(input.sqrMagnitude > 0)
        {
            // mse calcula el angulo al q tengo q rotarle en funcion de los input y en fuincion hacia donde este orientada la camara
            float anguloRotcion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;

            transform.eulerAngles = new Vector3(0, anguloRotcion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotcion, 0) * Vector3.forward;
            
            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        } 



       


    }
}
