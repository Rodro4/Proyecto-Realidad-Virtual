using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerClon;
    public Transform portalSalida;
    public Transform portalEntrada;
    public Transform cam;

    private void Update()
    {
        cam.localPosition = new Vector3(-playerClon.localPosition.x, -playerClon.localPosition.y, playerClon.localPosition.z);
        cam.localRotation = Quaternion.AngleAxis(180, Vector3.forward) * playerClon.localRotation;

        // Forma alternativa
        //cam.localRotation = playerClon.localRotation;
        //cam.Rotate(0, 180, 0, Space.World);
    }

    // Resetea la posición y rotación de los portales
    public void resetCam()
    {
        cam.rotation = portalSalida.rotation;
        cam.position = portalSalida.position;
    }
}