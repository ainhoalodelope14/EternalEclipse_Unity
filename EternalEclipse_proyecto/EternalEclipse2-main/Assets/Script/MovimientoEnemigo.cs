using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidadEnemigo = 2f;
    public Transform jugador; // Referencia al GameObject del jugador
    public float distanciaAtaque = 10f; // Distancia mínima para atacar
    private Vector2 direccionAnterior; // Para almacenar la dirección anterior del enemigo
    private Animator animator; // Referencia al Animator
    public Slider vidaJugador; // vida jugador
    private bool canAtack = true;

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

        animator.SetFloat("Distancia", distanciaAlJugador); // Hace la animación de atacar dependiendo de la distancia

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
        canAtack = false;
        vidaJugador.value -= 15; // Le quita vida
        yield return new WaitForSeconds(2f); // Espera 2 segundos al proximo ataque 
        canAtack = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ataqueJugador"))
        {
            animator.SetTrigger("muerto");
            // Invoca el método HandleDeathDelayed después de un retraso de 1 segundo
            Invoke("seMuere", 0.30f);
        }
    }

    void seMuere()
    {
        Destroy(gameObject); // Se destruye el enemigo si este muere
    }
}
