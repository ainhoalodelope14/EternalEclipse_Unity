using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerderVida : MonoBehaviour
{
    public Slider sliderVida;
    public float cantidadDePerdida = 10f;
    private Animator muerto;
    private bool muerteReproducida = false;
    // Agrega una variable para almacenar el intervalo entre mejoras de vida
    private float intervaloMejoraVida;
    // Variable para almacenar el tiempo de la última mejora de vida
    private float tiempoUltimaMejoraVida;

    void Start()
    {
        muerto = GetComponent<Animator>();

        // Inicializa el tiempo de la última mejora de vida al inicio
        tiempoUltimaMejoraVida = Time.time;

        // Inicializa el intervalo de mejora de vida desde PlayerPrefs
        intervaloMejoraVida = PlayerPrefsSettings.instance.getTiempoRegeneracionVida();

        // Inicializa la vida máxima desde PlayerPrefs
        sliderVida.maxValue = PlayerPrefsSettings.instance.getSaludMaxima();
        sliderVida.value = sliderVida.maxValue; // Inicializa la vida actual al máximo
    }

    void Update()
    {
        // Verifica si ha pasado el intervalo de tiempo para una nueva mejora de vida
        if (Time.time >= tiempoUltimaMejoraVida + intervaloMejoraVida)
        {
            MejorarVida(); // Llama al método para mejorar la vida
        }

        if (sliderVida.value <= 0 && !muerteReproducida)
        {
            // Aplicar el desplazamiento al objeto del jugador
            muerto.SetTrigger("EstaMuerto");
            muerteReproducida = true;
        }
    }

    // Método para mejorar la vida
    private void MejorarVida()
    {
        /// Calcula la cantidad de vida que se debe incrementar
        float incrementoVida = PlayerPrefsSettings.instance.getRegeneracionVida();

        // Aumenta la vida, pero asegurando que no supere el máximo
        sliderVida.value = Mathf.Min(sliderVida.value + incrementoVida, sliderVida.maxValue);

        // Actualiza el tiempo de la última mejora de vida
        tiempoUltimaMejoraVida = Time.time;
    }

    public void MejorarTiempoRegeneracionVida(float nuevaRegeneracion)
    {
        // Reducir el tiempo de regeneración de vida en una fracción de nuevaRegeneracion
        intervaloMejoraVida *= 1f - nuevaRegeneracion;

        // Asegurar que el intervalo de mejora de vida no sea menor que un valor mínimo
        if (intervaloMejoraVida < 0.1f)
        {
            intervaloMejoraVida = 0.1f;
        }

        // Actualizar el tiempo de regeneración de vida en PlayerPrefs
        PlayerPrefsSettings.instance.setTiempoRegeneracionVida(intervaloMejoraVida);
    }
}
