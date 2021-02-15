using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_2 : MonoBehaviour
{
     public int Acceleration = 20;

    public Vector3 speed;

    public Rigidbody rb;
    public bool cubeIsOnTheGround = true;

    public float FrictionFactor = 0.9f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        
        // Add accelartion in function od inputs to speed 
        Vector3 realAcceleration =new Vector3(horizontalInput* Acceleration , 0, VerticalInput * Acceleration);
        speed += realAcceleration;
        // Add speed to pôsition 
        transform.position += speed * Time.deltaTime;
        //Decelaration 
        speed *= FrictionFactor;

        if(Input.GetButtonDown("Jump") && cubeIsOnTheGround)
        {
            rb.AddForce(new Vector3(0,5,0), ForceMode.Impulse);
            cubeIsOnTheGround = false;
            AudioManager.audioInstance.jumpSrc.PlayOneShot(AudioManager.audioInstance.jumpClp);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            cubeIsOnTheGround = true;
        }

    }
}
