using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableLayerChange : MonoBehaviour
{
    public void Grabbed()
    {
        int LayerGrababble = LayerMask.NameToLayer("Grabables");
        GetComponent<CapsuleCollider>().isTrigger= true;
        gameObject.layer = LayerGrababble;
    }

    public void Released()
    {
        int LayerDefault = LayerMask.NameToLayer("Default");
        GetComponent<CapsuleCollider>().isTrigger = false;
        gameObject.layer = LayerDefault;
    }
}
