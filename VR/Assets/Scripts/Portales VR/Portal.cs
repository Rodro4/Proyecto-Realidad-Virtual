using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform player;
    public Transform otherPortal;
    public CapsuleCollider sphereColliderGround;
    public CapsuleCollider capsuleCollider;
    public Collider manoIzq;
    public Collider manoDer;
    public Transform thisPortal;
    public Transform portal1;
    public Transform portal2;



    private void OnTriggerEnter(Collider other)
    {
        if (other == capsuleCollider)
        {
            sphereColliderGround.enabled = true;
            capsuleCollider.isTrigger = true;

            manoDer.isTrigger = true;
            manoIzq.isTrigger = true;
        }

        if (other == sphereColliderGround)
        {
            Vector3 direction = otherPortal.up / 1;
            Vector3 distance = new Vector3(player.position.x - thisPortal.position.x, player.position.y - thisPortal.position.y, player.position.z - thisPortal.position.z);
            Vector3 newPosition = new Vector3(otherPortal.position.x + distance.x, otherPortal.position.y + distance.y, otherPortal.position.z + distance.z);

            player.position = newPosition;
            player.position += direction;

            float up = Vector3.SignedAngle(thisPortal.up, otherPortal.up, Vector3.Cross(portal1.up, portal2.up));
            float forward = Vector3.SignedAngle(thisPortal.forward, otherPortal.forward, Vector3.Cross(portal1.forward, portal2.forward));
            float right = Vector3.SignedAngle(thisPortal.right, otherPortal.right, Vector3.Cross(portal1.right, portal2.right));
           
            player.gameObject.GetComponent<Rigidbody>().velocity = Quaternion.Euler(0, 180-up, 0) * player.gameObject.GetComponent<Rigidbody>().velocity;
            player.Rotate(0,180-up,0, Space.World );
        }
    }

    private void OnTriggerExit(Collider other)
    {
        capsuleCollider.isTrigger = false;
        sphereColliderGround.enabled = false;
    }
}
