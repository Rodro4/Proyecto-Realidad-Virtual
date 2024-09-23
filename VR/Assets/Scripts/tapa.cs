using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapa : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int tornillos;
    private Rigidbody rigidbod;
    
    void Start()
    {
        rigidbod= GetComponent<Rigidbody>();
    }

    public void Desatornillar()
    {
        tornillos--;
        if(tornillos == 0)
        {
            rigidbod.AddRelativeForce(0,0,-5);
            rigidbod.constraints = RigidbodyConstraints.None;
        }
    }
}
