using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public static float maxSpeed = 400000;
    public static float minSpeed = 10000;
    public static float speed;
    private Rigidbody rb;
    
    
    public GameObject powerBar;

    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //StartShooting();
        Movement();
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
                
            rb.AddForce(transform.forward * speed * Time.deltaTime);       
            score++;
                
        }
    }
}
