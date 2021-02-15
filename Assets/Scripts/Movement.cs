using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Acceleration = 20;

    public Vector3 speed;
    
    public Rigidbody rb;

    public float FrictionFactor = 0.9f;

    public bool cubeIsOnTheGround = true;

    private void Start()
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
    
    private void OnTriggerEnter(Collider col )
    {
        if (col.gameObject.tag == "ButtonChangeColor")
        {
            Debug.Log("OH");
            FindObjectOfType<GameManager>().GetComponent<GameManager>().ChangeColor();
            AudioManager.audioInstance.buttonSrc.PlayOneShot(AudioManager.audioInstance.buttonClp);


        }
    }
    

}
