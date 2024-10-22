using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ThirdPerson : MonoBehaviour
{

    //[SerializeField] private float velocidadMovimiento;

    private CharacterController controller;

    [SerializeField] private float smoothing; // tiempo de suavizado
    private Camera cam;
    private float velocidadRotacion;
    private Animator anim;
    void Start()
    {
        // bloquea el raton en el centro de la pantalla y lo oculta
        // Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();  

        cam = Camera.main;
    }


    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        //Vector3 movimiento = new Vector3(h, 0, v ).normalized;
        Vector2 input = new Vector2(h, v).normalized;

      
        // sqrMagnitude es mas optimo que magnitude
        if (input.sqrMagnitude > 0)
        {
            // mse calcula el angulo al q tengo q rotarle en funcion de los input y en fuincion hacia donde este orientada la camara
            float anguloRotcion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            
            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotcion, ref velocidadRotacion, smoothing); // ya esta suavizado
            
            transform.eulerAngles = new Vector3(0, anguloRotcion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotcion, 0) * Vector3.forward;

            controller.Move(movimiento * 5 * Time.deltaTime);
            
            anim.SetBool("walking", true);


        }
        else
        {
            anim.SetBool("walking", false);
        }

    }
}
