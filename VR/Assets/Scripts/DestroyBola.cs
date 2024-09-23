using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBola : MonoBehaviour
{
    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 4)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }
}
