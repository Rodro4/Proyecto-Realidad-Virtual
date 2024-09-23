using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Teclado : MonoBehaviour
{
    // Start is called before the first frame update

    private int codigo = 0;
    public int solucion;
    public int posicion = 1000;
    public GameObject[] teclas = new GameObject[9];
    public Material defaultMat;
    public Material rojo;
    public Material verde;
    public Material amarillo;
    private bool error, lleno, fin;
    [SerializeField] private GameObject PORTAL;
    public void IntroducirNum(int num)
    {
        if (!fin)
        {
            if (error)
            {
                error = false;
                foreach (GameObject go in teclas)
                {
                    go.GetComponent<MeshRenderer>().material = defaultMat;
                }

            }
            else if (posicion < 1)
            {
                foreach (GameObject go in teclas)
                {

                    go.GetComponent<MeshRenderer>().material = amarillo;
                }
            }
            else
            {
                codigo += num * posicion;
                posicion = posicion / 10;
            }
        }


    }

    public void Borrar()
    {
        if (!fin)
        {
            error = true;
            foreach (GameObject go in teclas)
            {
                go.GetComponent<MeshRenderer>().material = rojo;
                
            }
            codigo = 0;
            posicion = 1000;
        }

    }

    public void Aceptar()
    {
        if (!fin)
        {
            if (codigo == solucion)
            {
                fin = true;
                foreach (GameObject go in teclas)
                {
                    go.GetComponent<MeshRenderer>().material = verde;

                    go.GetComponent<XRSimpleInteractable>().enabled = false;

                    PORTAL.SetActive(true);
                }
            }
            else
            {
                error = true;
                foreach (GameObject go in teclas)
                {
                    go.GetComponent<MeshRenderer>().material = rojo;

                }
                codigo = 0;
                posicion = 1000;
            }
        }

    }
}
