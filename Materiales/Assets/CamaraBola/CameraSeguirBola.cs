using UnityEngine;

public class CameraSeguirBola : MonoBehaviour
{
    [Header("Objetivo a seguir")]
    public Transform bola;

    [Header("Configuraci�n de c�mara")]
    public Vector3 offset = new Vector3(0, 0.1f, -6); // Muy cerca del piso
    public float suavizadoPosicion = 6f;  // Suaviza el movimiento
    public float suavizadoRotacion = 7f;  // Suaviza la rotaci�n

    private bool seguir = false;

    void LateUpdate()
    {
        if (bola == null) return;

        // Posici�n deseada: X/Z siguen a la bola, Y fijo a offset.y
        Vector3 posicionDeseada = new Vector3(
            bola.position.x + offset.x,
            offset.y,             // altura fija
            bola.position.z + offset.z
        );

        // Movimiento suave
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizadoPosicion * Time.deltaTime);

        // Rotaci�n suave mirando hacia la bola a la altura de la c�mara
        Vector3 objetivoRotacion = new Vector3(bola.position.x, offset.y, bola.position.z);
        Quaternion rotacionDeseada = Quaternion.LookRotation(objetivoRotacion - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, suavizadoRotacion * Time.deltaTime);
    }

    // Llamado desde ControlBola al lanzar la bola
    public void ActivarSeguimiento()
    {
        seguir = true;
        transform.SetParent(null); // Desacopla de la bola
    }
}
