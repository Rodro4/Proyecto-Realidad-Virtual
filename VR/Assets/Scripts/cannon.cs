using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public GameObject ballPrefab;
    private float fireInterval = 5;
    private float timer = 0;
    public Transform target;
    private Rigidbody ballRigidbody;
    public float ballVelocity;
   
    void Update()
    {
        timer += Time.deltaTime;

        if (ballRigidbody != null)
        {

            ballVelocity = ballRigidbody.velocity.magnitude;
        }

        if (timer >= fireInterval)
        {
            Fire();
            timer = 0;
            GetComponent<AudioSource>().Play();
        }
    }

    void Fire()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
        ball.active = true;
        ballRigidbody = ball.GetComponent<Rigidbody>();
        transform.LookAt(target);
        ball.GetComponent<Rigidbody>().AddForce(transform.forward * 20);
    }
}
