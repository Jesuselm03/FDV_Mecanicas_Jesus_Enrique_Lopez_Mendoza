using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;

public class ControlJugador : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    private bool estaMirandoDerecha = true;

    public float fuerzaDeSalto = 500f; 
    private bool estaSaltando = false; 

    public TextMeshProUGUI textoPuntuacion;
    public int puntosParaMejora = 5;
    public float aumentoDeSalto = 200f;
    
    private int puntuacion = 0;
    private bool mejoraAplicada = false;

    private Rigidbody2D rb; 
    private Animator miAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        miAnimator = GetComponent<Animator>();
        ActualizarTextoPuntuacion();
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimientoHorizontal * velocidadMovimiento, rb.linearVelocity.y);

        miAnimator.SetFloat("Velocidad", Mathf.Abs(movimientoHorizontal));

        if (movimientoHorizontal > 0 && !estaMirandoDerecha)
        {
            Girar();
        }
        else if (movimientoHorizontal < 0 && estaMirandoDerecha)
        {
            Girar();
        }

        // SALTO
        if (Input.GetButtonDown("Jump") && !estaSaltando)
        {
            rb.AddForce(transform.up * fuerzaDeSalto); 
            estaSaltando = true;
            miAnimator.SetBool("EstaEnSuelo", false);
        }
    }

    void Girar()
    {
        estaMirandoDerecha = !estaMirandoDerecha;
        Vector3 laEscala = transform.localScale;
        laEscala.x *= -1;
        transform.localScale = laEscala;
    }

    // COLISIONES
    private void OnCollisionEnter2D(Collision2D otroObjeto)
    {
        // No chocar
        if (otroObjeto.gameObject.layer == LayerMask.NameToLayer("NoCollis"))
        {
            return; 
        }

        // Aterrizaje
        if (otroObjeto.gameObject.CompareTag("Suelo") || otroObjeto.gameObject.CompareTag("PlataformaMovil"))
        {
            estaSaltando = false;
            miAnimator.SetBool("EstaEnSuelo", true);

            if (otroObjeto.gameObject.CompareTag("Suelo"))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            }
        }

        // Plataformas móviles
        if (otroObjeto.gameObject.CompareTag("PlataformaMovil"))
        {
            transform.SetParent(otroObjeto.transform);
        }

        // Plataformas invisibles
        if (otroObjeto.gameObject.layer == LayerMask.NameToLayer("PlatInv"))
        {
            TilemapRenderer tilemapDeLaPlataforma = otroObjeto.gameObject.GetComponent<TilemapRenderer>();
            
            if (tilemapDeLaPlataforma != null)
            {
                tilemapDeLaPlataforma.enabled = true;
            }
        }
    }

    // DESPEGARSE
    private void OnCollisionExit2D(Collision2D otroObjeto)
    {
        if (otroObjeto.gameObject.CompareTag("Suelo") || otroObjeto.gameObject.CompareTag("PlataformaMovil"))
        {
            estaSaltando = true;
            miAnimator.SetBool("EstaEnSuelo", false);
        }

        if (otroObjeto.gameObject.CompareTag("PlataformaMovil"))
        {
            transform.SetParent(null);
        }
    }

    // RECOLECCIÓN
    private void OnTriggerEnter2D(Collider2D otroObjeto)
    {
        if (otroObjeto.gameObject.CompareTag("Recolectable"))
        {
            puntuacion = puntuacion + 1;
            ActualizarTextoPuntuacion();
            Destroy(otroObjeto.gameObject);

            if (puntuacion >= puntosParaMejora && !mejoraAplicada)
            {
                fuerzaDeSalto = fuerzaDeSalto + aumentoDeSalto;
                mejoraAplicada = true;
                Debug.Log("¡Potencia de salto mejorada!");
            }
        }
    }

    // ACTUALIZAR PUNTOS
    void ActualizarTextoPuntuacion()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntuación: " + puntuacion;
        }
    }

}