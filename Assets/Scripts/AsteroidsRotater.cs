using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsRotater : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private int rotateSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.angularVelocity = Random.insideUnitSphere * rotateSpeed;
    }
}
