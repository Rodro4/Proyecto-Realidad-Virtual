using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornillos : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private tapa t;
    private bool used;
    private Rigidbody rigidbod;

    private void Start()
    {
        rigidbod = GetComponent<Rigidbody>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!used && other.tag == "destornillador")
        {
            Debug.Log("DESATORNILLADO");
            rigidbod.constraints = RigidbodyConstraints.None;
            rigidbod.AddRelativeForce(0, 0, -5);
            t.Desatornillar();
            used= true;
        }
    }
}
