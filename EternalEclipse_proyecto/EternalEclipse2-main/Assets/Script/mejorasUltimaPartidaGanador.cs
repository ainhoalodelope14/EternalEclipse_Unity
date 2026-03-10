using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mejorasUltimaPartidaGanador : MonoBehaviour
{
    public Text velocidad;
    public Text cooldownHabilidad;
    public Text velocidadHabilidad;
    public Text regeneracionVida;
    public Text tiempoRegeneracionVida;
    public Text saludMax;

    // Start is called before the first frame update
    void Start()
    {
        var gameData = PlayerPrefsSettings.instance;
        gameData.cargarJson(); // Se carga todo el json y se aplica dicho texto a cada uno
        Debug.Log("Se cargaron los datos" + gameData.ganadorJson.velocidadPersonaje.ToString());
        velocidad.text = "Velocidad: " + gameData.ganadorJson.velocidadPersonaje.ToString();
        cooldownHabilidad.text = "Cooldown habilidad: " + gameData.ganadorJson.cooldownHabilidad.ToString();
        velocidadHabilidad.text = "Velocidad habilidad: " + gameData.ganadorJson.velocidadHabilidad.ToString();
        regeneracionVida.text = "Regeneración vida: " + gameData.ganadorJson.regeneracionVida.ToString();
        tiempoRegeneracionVida.text = "Tiempo de regeneración de vida: " + gameData.ganadorJson.tiempoRegeneracionVida.ToString();
        saludMax.text = "Salud Máxima: " + gameData.ganadorJson.saludMaxima.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
