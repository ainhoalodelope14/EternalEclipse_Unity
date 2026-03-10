using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mago : MonoBehaviour
{
    public float velocidadEnemigo = 2f;
    public Transform jugador; // Referencia al GameObject del jugador
    public float distanciaAtaque = 3f; // Distancia mínima para atacar
    private Vector2 direccionAnterior; // Para almacenar la dirección anterior del enemigo
    private Animator animator; // Referencia al Animator
    public Slider vidaJugador;
    private bool canAtack = true;
    public float distanciaDesplazamiento = 1.0f; // Distancia desde el enemigo donde se lanzará el proyectil


    public GameObject proyectilPrefab; // Prefab del proyectil
    private bool isDead = false;

    void Start()
    {
        direccionAnterior = Vector2.zero; // Inicializar la dirección anterior como cero al inicio
        animator = GetComponent<Animator>(); // Obtener la referencia al Animator
    }

    void Update()
    {

        // Obtener la dirección hacia la que se está moviendo el enemigo
        Vector2 direccionActual = (new Vector2(jugador.position.x, jugador.position.y) - new Vector2(transform.position.x, transform.position.y)).normalized;

        // Calcular la distancia al jugador
        float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);


        animator.SetFloat("Distancia", distanciaAlJugador);

        if (distanciaAlJugador <= distanciaAtaque && canAtack)
        {
            // Si está dentro de la distancia de ataque, atacar
            StartCoroutine(Atacar());
        }
        else
        {
            // Mover al enemigo
            transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidadEnemigo * Time.deltaTime);

            // Si la dirección actual es diferente a la anterior
            if (direccionActual != direccionAnterior)
            {
                // Actualizar la dirección anterior
                direccionAnterior = direccionActual;

                // Girar el sprite según la dirección de movimiento
                if (direccionActual.x < 0) // Si se está moviendo hacia la izquierda
                {
                    // Voltear el sprite hacia la izquierda
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (direccionActual.x > 0) // Si se está moviendo hacia la derecha
                {
                    // Mantener el sprite con su escala original
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
        
    }

    private IEnumerator Atacar()
    {
        LanzarHabilidad();
        canAtack = false;
        Debug.Log(vidaJugador.value);
        yield return new WaitForSeconds(2f);
        canAtack = true;
    }

    void LanzarHabilidad()
{
    // Dirección hacia el jugador
    Vector3 direccionHaciaJugador = (jugador.position - transform.position).normalized;

    // Rotación del proyectil en el plano XZ (para que apunte hacia adelante)
    Quaternion rotacionProyectil = Quaternion.LookRotation(new Vector3(direccionHaciaJugador.x, 0, direccionHaciaJugador.y));

    // Instancia el proyectil en el punto de lanzamiento
    GameObject proyectil = Instantiate(proyectilPrefab, transform.position, rotacionProyectil);

    // Añade una fuerza al proyectil para que se desplace hacia el jugador
    Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
    if (rb != null)
    {
        rb.velocity = direccionHaciaJugador * 5f;
    }
}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ataqueJugador"))
        {
            animator.SetTrigger("muerto");
            // Invoca el método HandleDeathDelayed después de un retraso de 1 segundo
            Invoke("seMuere", 1f);
        }
    }

    void seMuere()
    {
        Destroy(gameObject);
    }
}
