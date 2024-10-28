using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento, escalaGravedad,radioDeteccion;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Vector3 movimientoVertical;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform pies;
    [SerializeField] private float alturaSalto;

    void Start()
    {
        // bloquea el raton en el centro de la pantalla y lo oculta
        //Cursor.lockState = CursorLockMode.Locked;
       controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;
        float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        if(input.sqrMagnitude > 0)
        {
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;
            controller.Move(movimiento * 5 * Time.deltaTime);
        }
        AplicarGravedad();
        DeteccionSuelo();
     
    }
    private void AplicarGravedad()
    {
        // mi mov v en la y va aumentando a cierta escala por segundo
        movimientoVertical.y += escalaGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    }
    private void DeteccionSuelo()
    {
        // tengo que lanzar una bola de deteccion en mis pies para detectar si 
        Collider[] collsDetectados = Physics.OverlapSphere(pies.position, radioDeteccion, queEsSuelo);
        // si existe al menos un collider bajo mis pies
        if(collsDetectados.Length > 0)
        {
            movimientoVertical.y = 0;
            Saltar();
        }

    }
    // esto sirve para dibujar cualquier figura en la escena
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(pies.position, radioDeteccion);
    }
    private void Saltar()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
        }
    }
}
