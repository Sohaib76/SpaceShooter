using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;


public class PLayerController : MonoBehaviour 
{
    public float speed;

    public float xMin, xMax, zMin, zMax;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private Rigidbody rb;

    public float tilt;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
        void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	 void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.velocity = (movement * speed);

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x,xMin, xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, zMin,  zMax)
         );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }


	

}
