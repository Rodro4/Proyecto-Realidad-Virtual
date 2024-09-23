using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public Transform portal1;
    public Transform portal2;

    public PortalCamera portalCamera1; // Asigna el prefab PortalCamera en el inspector
    public PortalCamera portalCamera2; // Asigna el prefab PortalCamera en el inspector

    private int aux = 1;
    public void portalear()
    {
        if (aux == 1)
        {
            RayCastPortal(1);
            aux = 2;
        }
        else if (aux == 2)
        {
            RayCastPortal(2);
            aux = 1;
        }
       
    }

    void RayCastPortal(int portalID)
    {
        // Crear un rayo desde la posición de la cámara en la dirección de su vista
        Ray ray = new Ray(transform.position, transform.forward);
        
        // Almacenar la información de colisión del rayo
        RaycastHit hit;

        // Lanzar el rayo y comprobar si ha colisionado con algún objeto
        if (Physics.Raycast(ray, out hit))
        {
            // Imprimir el nombre del objeto colisionado en la consola
            Debug.Log("Objeto colisionado: " + hit.collider.gameObject.name);
            GameObject collisionObject = hit.collider.gameObject;
            Vector3 collisionPoint = hit.point;

            // Coloca el portal 1 o 2 según el ID recibido
            if (portalID == 1)
            {
                portal1.rotation = collisionObject.transform.rotation;
                portal1.position = collisionPoint;
                portal1.position += (collisionObject.transform.up / 100f);
                // Reiniciamos posición y rotación de los portales
                portalCamera1.resetCam();

            }
            else if (portalID == 2)
            {
                portal2.position = collisionPoint;
                portal2.rotation = collisionObject.transform.rotation;
                portal2.position += (collisionObject.transform.up / 100f);
                // Reiniciamos posición y rotación de los portales
                portalCamera2.resetCam();
            }
        }
    }




}
