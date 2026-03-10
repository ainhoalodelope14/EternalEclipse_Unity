using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    public GameObject tooltipPanel; // El Panel que actúa como el tooltip
    public Text tooltipText; // El Text dentro del Panel que muestra la descripción

    void Awake()
    {
        // Asegúrate de que solo hay una instancia del TooltipManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Inicialmente, desactiva el panel del tooltip
        tooltipPanel.SetActive(false);
    }

    public void ShowTooltip(string description, Vector3 position)
    {
        tooltipPanel.SetActive(true);
        tooltipText.text = description;
        // Mueve el tooltip a la posición del cursor, con un pequeño desplazamiento
        tooltipPanel.transform.position = position + new Vector3(10, -10, 0);
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }
}
