using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dispensador : MonoBehaviour
{
    [SerializeField] private GameObject objeto;
    private GameObject[] objetos;
    private string tagObjeto;
   
    void Start()
    {
        tagObjeto = objeto.tag;
    }

    public void Dispensar()
    {
        objetos = GameObject.FindGameObjectsWithTag(tagObjeto);
        foreach (GameObject objeto in objetos)
        {
            if (objeto.activeSelf)
            {
                Destroy(objeto);
            }
        }
        GameObject gameo = Instantiate (objeto);
        gameo.SetActive(true);
        gameo.transform.position  = objeto.transform.position;
        gameo.transform.localScale= objeto.transform.localScale;
        gameo.transform.rotation= objeto.transform.rotation;
    }
        
}
