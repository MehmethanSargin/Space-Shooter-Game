using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary 
{
  public float XMin, XMax, ZMin, ZMax;
}

public class PlayerController : MonoBehaviour
{
    public Boundary boundary;
    
    Rigidbody rb;

    [SerializeField]
    private int speed;

    [SerializeField]
    private int tilt;
    
    [SerializeField]
    private GameObject shot;

    [SerializeField]
    private GameObject shotSpawnArea;

    [SerializeField]
    private float nextFire;

    [SerializeField]
    private float fireRate;

    AudioSource audioPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawnArea.transform.position, shotSpawnArea.transform.rotation);
            audioPlayer.Play();
        }
    }

    void LateUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = move * speed;
        Vector3 position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.XMin, boundary.XMax),
            0,
            Mathf.Clamp(rb.position.z, boundary.ZMin, boundary.ZMax));
        rb.position = position;
        rb.rotation = Quaternion.Euler(0,0,rb.velocity.x * tilt);
    }  
}