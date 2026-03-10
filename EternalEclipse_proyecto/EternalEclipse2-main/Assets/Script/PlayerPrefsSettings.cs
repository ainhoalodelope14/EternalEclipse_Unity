using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPrefsSettings : MonoBehaviour
{
    public static PlayerPrefsSettings instance;

    public int numOleada;
    // Variables para las mejoras
    public float velocidadPersonaje;
    public float cooldownHabilidad;
    public float velocidadHabilidad;
    public float regeneracionVida;
    public float tiempoRegeneracionVida;
    public float saludMaxima;

    private string Filepath;
    public ultimaPartida ganadorJson;

    void Awake()
    {
        // Se mira si la intstancia existe sino se crea una
        if (instance == null)
        {
            instance = this; // Intancia única
            DontDestroyOnLoad(gameObject); // Para que no se elimine si se cambia de escena
            this.Clear(); // Limpia las variables de mejoras cuando reinicia el juego

            // Para guardar los datos en archivo json
            Filepath = Path.Combine(Application.persistentDataPath, "gamedata.json"); 
        }
        else
        {
            Destroy(gameObject); // Destruye la instancia si esta ya existe
        }
    }

    public void Clear() // Método para reniciar todas las mejoras
    {
        DontDestroyOnLoad(gameObject);
        setNumOleada(1);
        setVelocidadPersonaje(3f);
        setCooldownHabilidad(2f);
        setVelocidadHabilidad(3f);
        setRegeneracionVida(1f);
        setTiempoRegeneracionVida(3f);
        setSaludMaxima(100f);
    }

    // Get y set del número de oleada
    public int getNumOleada() 
    {
        return PlayerPrefs.GetInt("numOleada", 1);
    }

    public void setNumOleada(int numOleada)
    {
        PlayerPrefs.SetInt("numOleada", numOleada);
    }

    // Get y set de la velocdad del personaje
    public float getVelocidadPersonaje()
    {
        return velocidadPersonaje = PlayerPrefs.GetFloat("velocidadPersonaje", 3f);
    }

    public void setVelocidadPersonaje(float velocidadPersonaje)
    {
        PlayerPrefs.SetFloat("velocidadPersonaje", velocidadPersonaje);
    }

    // Get y set de la cooldown de habilidad del personaje
    public float getCooldownHabilidad()
    {
        return cooldownHabilidad = PlayerPrefs.GetFloat("cooldownHabilidad", 1f);
    }

    public void setCooldownHabilidad(float cooldownHabilidad)
    {
        PlayerPrefs.SetFloat("cooldownHabilidad", cooldownHabilidad);
    }

    // Get y set de la velocdad del ataque del personaje
    public float getVelocidadHabilidad()
    {
        return velocidadHabilidad = PlayerPrefs.GetFloat("velocidadHabilidad", 3f);
    }

    public void setVelocidadHabilidad(float velocidadHabilidad)
    {
        PlayerPrefs.SetFloat("velocidadHabilidad", velocidadHabilidad);
    }
 
    // Get y set de la regeneracion de vida del personaje
    public float getRegeneracionVida()
    {
        return regeneracionVida = PlayerPrefs.GetFloat("regeneracionVida", 1f);
    }
    public void setRegeneracionVida(float regeneracionVida)
    {
        PlayerPrefs.SetFloat("regeneracionVida", regeneracionVida);
    }

    // Get y set de la tiempo de regeneracion de vida del personaje
    public float getTiempoRegeneracionVida()
    {
        return regeneracionVida = PlayerPrefs.GetFloat("tiempoRegeneracionVida", 3f);
    }
    public void setTiempoRegeneracionVida(float tiempoRegeneracionVida)
    {
        PlayerPrefs.SetFloat("tiempoRegeneracionVida", tiempoRegeneracionVida);
    }

    // Get y set de la salud maxima del personaje
    public float getSaludMaxima()
    {
        return saludMaxima = PlayerPrefs.GetFloat("saludMaxima", 100f);
    }

    public void setSaludMaxima(float saludMaxima)
    {
        PlayerPrefs.SetFloat("saludMaxima", saludMaxima);
    }

    // Método para guardar en json
    public void guardarJson()
    {
        // Clase con los atributos que se van a guardar
        ultimaPartida ganador = new ultimaPartida();

        ganador.velocidadPersonaje = getVelocidadPersonaje();
        ganador.cooldownHabilidad = getCooldownHabilidad();
        ganador.velocidadHabilidad = getVelocidadHabilidad();
        ganador.regeneracionVida = getRegeneracionVida();
        ganador.tiempoRegeneracionVida = getTiempoRegeneracionVida();
        ganador.saludMaxima = getSaludMaxima();

        // Se pasa todo el objeto a json
        string playerToJson = JsonUtility.ToJson(ganador);

        //Se guarda el json en una ruta
        File.WriteAllText(Filepath, playerToJson);
    }

    // Metodo para cargar los datos guardados en json
    public void cargarJson()
    {
        if (File.Exists(Filepath)) // Si el archivo existe
        {
            // Lee el archivo y lo pasa de json a la clase ultimaPartida
            string json = File.ReadAllText(Filepath);
            ganadorJson = (ultimaPartida)JsonUtility.FromJson(json, typeof(ultimaPartida));
        }
    }
}

[System.Serializable]
public class ultimaPartida // Clase para guardar todos los datos
{
    public float velocidadPersonaje;
    public float cooldownHabilidad;
    public float velocidadHabilidad;
    public float regeneracionVida;
    public float tiempoRegeneracionVida;
    public float saludMaxima;
}






