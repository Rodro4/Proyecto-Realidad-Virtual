using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bhaptics.SDK2;

public class velocidad : MonoBehaviour
{
    public int objectID;
    public int cannonID;
    public int[] motores = new int[40];
    public float velocidadColision;
    public float velocidadBola;
    public Hold holdScript;
    public cannon cannonScript;
    public int velocidadInt;
    public int velocidadIntColision;
    public int velocidadIntBola;

    // Start is called before the first frame update
    void Start()
    { 

         objectID = int.Parse(this.name);
         holdScript = GameObject.FindObjectOfType<Hold>();

         cannonID = int.Parse(this.name);
         cannonScript = GameObject.FindObjectOfType<cannon>();

    }

    // Update is called once per frame
    void Update()
    {
        velocidadColision = holdScript.velocity;
        velocidadBola = cannonScript.ballVelocity;

        velocidadIntColision = (int)velocidadColision;   
        velocidadIntBola = (int)velocidadBola;

        velocidadInt=velocidadIntBola + velocidadIntColision;

        for (int i = 0; i < 40; i++)
        {
            motores[i] = 0;
        }

        if (velocidadInt > 100)
        {
            velocidadInt = 100;
        } else if (velocidadInt < 50)
        {
            velocidadInt = 50;
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        motores[objectID]=velocidadInt;
        BhapticsLibrary.PlayMotors(0, motores, 75);
    }
}
