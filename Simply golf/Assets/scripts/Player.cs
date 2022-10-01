using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public static float maxSpeed = 400000f;
    public static float minSpeed = 44074.6f;
    public static float speed;
    private Rigidbody rb;
    private bool moving;
    

    private Vector3 PastPos;
    
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
        StopMoving();   
        Movement();
    }
    void Movement()
    {
        if (!moving)
        {
            powerBar.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SavePos();
                moving = true;
                rb.isKinematic = false;
                rb.AddForce(transform.forward * speed * Time.deltaTime);
                score++;
            }
        }
    }
    void SavePos()
    {
        PastPos = transform.position;
    }
    void LoadPos()
    {
        rb.isKinematic = true;
        moving = false;
        transform.position = PastPos;
    }
    void StopMoving()
    {
        if (moving)
        {
            powerBar.SetActive(false);
            if (rb.velocity.magnitude <= 0.1f)
            {
                
                moving = false;
                rb.isKinematic = true;
                
                Debug.Log("Stopped");
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Water")
        {
            LoadPos();
        }
    }


}
