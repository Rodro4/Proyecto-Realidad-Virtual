using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] Teclado teclado;
    [SerializeField] private int tipoTecla;

    public void Pulsar()
    {
        if (tipoTecla == 0)
        {
            teclado.IntroducirNum(number);
        }
        else if (tipoTecla == 1)
        {
            teclado.Borrar();
        }
        else if (tipoTecla == 2)
        {
            teclado.Aceptar();
        }
    }


}
