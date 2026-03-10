using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabilidadMago : MonoBehaviour
{
    public float tiempoDeVida = 5f; // Tiempo de vida del proyectil

    public Slider vidaJugador; // Vida jugador

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
{
    // Cuando la habilidad del mago ataca al jugador, la vida de este baja
    if (other.gameObject.CompareTag("jugador"))
    {
        if (vidaJugador != null)
        {
            vidaJugador.value -= 5; // Bajar vida
        }
        Destroy(gameObject); // Destruir el proyectil al impactar
    }
}
}
