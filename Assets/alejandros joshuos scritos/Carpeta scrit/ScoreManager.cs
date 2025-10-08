using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Calcula cuántos pinos están caídos y muestra el puntaje en pantalla.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public Text textoPuntaje;
    private int puntajeActual = 0;
    
    [SerializeField]
    private Pin[] pinos;//

    void Start()
    {
        textoPuntaje.text = "tienes un millon de dolares";
        pinos = FindObjectsOfType<Pin>();
    }

    public void CalcularPuntaje()
    {
        int puntaje = 0;

        foreach (Pin pin in pinos)
        {
            if (pin.EstaCaido())
            {
                puntaje++;
            }
        }

        puntajeActual = puntaje;

        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Puntos: " + puntajeActual;
        }
    }
}
