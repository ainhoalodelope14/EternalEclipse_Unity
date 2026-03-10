using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float velocidadEnemigo = 2f;
    public Transform jugador; // Referencia al GameObject del jugador
    public float distanciaAtaque = 10f; // Distancia mínima para atacar
    private Vector2 direccionAnterior; // Para almacenar la dirección anterior del enemigo
    private Animator animator; // Referencia al Animator
    public Slider vidaJugador; // Vida del jugador
    public Slider vidaBoss; // Vida boss
    private bool canAtack = true; // Booleano para atacar

    public GameObject pantallaVictory; // Para activar la pantalla de victoria

    void Start()
    {
        direccionAnterior = Vector2.zero; // Inicializar la dirección anterior como cero al inicio
        animator = GetComponent<Animator>(); // Obtener la referencia al Animator
        vidaBoss.value = vidaBoss.maxValue; // Se inicia con la vida maxima que tenga el slider
    }

    void Update()
    {
        // Obtener la dirección hacia la que se está moviendo el enemigo
        Vector2 direccionActual = (new Vector2(jugador.position.x, jugador.position.y) - new Vector2(transform.position.x, transform.position.y)).normalized;

        // Calcular la distancia al jugador
        float distanciaAlJugador = Vector2.Distance(transform.position, jugador.position);

        animator.SetFloat("movimiento", distanciaAlJugador); // Hacer animación de movimiento cuando vaya a por el jugador

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

    // 
    private IEnumerator Atacar()
    {
        canAtack = false; // Se deshabilita la capacidad de atacar
        vidaJugador.value -= 20; // Se quita vida al jugador
        yield return new WaitForSeconds(2f); // Wait de 2 segundos
        canAtack = true; // Puede volver a atacar
    }

    // Para el contacto con el ataque del jugador
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ataqueJugador"))
        {
            if (vidaBoss.value <= 0) // Si pierde la vida muere
            {
                animator.SetTrigger("muerto"); 
                Invoke("seMuere", 1f);
            }
            else{
                vidaBoss.value -= 10; // Pierde 10 de vida cada vez que le ataca el jugador
            }

        }
    }

    void seMuere()
    {
        Destroy(gameObject); // Se destruye el boss
        PlayerPrefsSettings.instance.guardarJson(); // Se guarda las mejoras en el json
        pantallaVictory.SetActive(true); // Muestra el canvas de victoria
        Time.timeScale = 0f; // Detén el tiempo del juego
    }
}
