using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;
using TMPro;
using UnityEngine.SceneManagement;


public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento, escalaGravedad,radioDeteccion;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Vector3 movimientoVertical;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform pies;
    [SerializeField] private float alturaSalto;

    private bool estaMuerto = false;

    [SerializeField] private float vidas;

    [SerializeField] TMP_Text Texto_vidas;

    [SerializeField] private Camera cam;

    void Start()
    {
        // bloquea el raton en el centro de la pantalla y lo oculta
        //Cursor.lockState = CursorLockMode.Locked;
       controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        Texto_vidas.text = "Vidas; " + vidas;

        if (estaMuerto) return;

        AplicarGravedad();
        DeteccionSuelo();
        MoverYRotar();
        Saltar();
     
    }
    private void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;

        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);

        if (input.sqrMagnitude > 0)
        {
            float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;
            controller.Move(movimiento * 5 * Time.deltaTime);
        }
    }
    private void AplicarGravedad()
    {
        // mi mov v en la y va aumentando a cierta escala por segundo
        movimientoVertical.y += escalaGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    }
    private bool DeteccionSuelo()
    {
        // tengo que lanzar una bola de deteccion en mis pies para detectar si 
        bool resultado = Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);
        return resultado;

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("ParteEnemigo"))
        {
           Rigidbody rbEnemigo = hit.gameObject.GetComponent<Rigidbody>();
            
            Vector3 direccionFuerza = hit.transform.position - transform.position;
            rbEnemigo.AddForce(direccionFuerza.normalized * 50, ForceMode.Impulse);
        }
    }
    public void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;
        if(vidas <=0)
        {
            SceneManager.LoadScene("Muerte");
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
