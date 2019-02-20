using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);

        if (Other.tag == "Player")
        {

            Instantiate(playerExplosion, Other.transform.position, Other.transform.rotation);
           
        }
        Destroy(Other.gameObject);
        Destroy(gameObject);
    }

}
