using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    GameObject playerExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary") 
        {
            return;
        }
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
