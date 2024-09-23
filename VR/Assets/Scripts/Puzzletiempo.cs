using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzletiempo : MonoBehaviour
{
    bool bot1;
    bool bot2;
    float clock = 0;
    public GameObject puerta;

    // Update is called once per frame
    void Update()
    {
        if(bot1 || bot2)
        {            
            clock += Time.deltaTime;
            if(clock > 3)
            {
                bot1= false;
                bot2= false;
                clock= 0;
            }
            else
            {
                if (bot1 && bot2)
                {
                    Debug.Log("ABIERTO");
                    puerta.SetActive(false);
                }
            }
        }
    }

    public void Pulsar1()
    {
        bot1= true;
        clock = 0;
        
    }

    public void Pulsar2()
    {
        bot2 = true;
        clock = 0;
    }
}
