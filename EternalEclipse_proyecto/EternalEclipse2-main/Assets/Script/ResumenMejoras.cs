using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumenMejoras : MonoBehaviour
{

    public Text textVelocidad;
    public Text textCooldown;
    public Text textVelocidadHabilidad;
    public Text textRegeneracionVida;
    public Text textTiempoRegeneracionVida;
    public Text textSaludMaxima;

    void Start()
    {
        // Obtener todas las mejoras desde PlayerPrefsSettings
        PlayerPrefsSettings settings = PlayerPrefsSettings.instance;

        // Construir el texto de las mejoras
        textVelocidad.text = "Velocidad: " + settings.getVelocidadPersonaje();
        textCooldown.text = "Cooldown Habilidad: " + settings.getCooldownHabilidad();
        textVelocidadHabilidad.text = "Velocidad Habilidad: " + settings.getVelocidadHabilidad();
        textRegeneracionVida.text = "Regeneración de Vida: " + settings.getRegeneracionVida();
        textTiempoRegeneracionVida.text = "Tiempo de Regeneración: " + settings.getTiempoRegeneracionVida();
        textSaludMaxima.text = "Salud Máxima: " + settings.getSaludMaxima();
    }
}
