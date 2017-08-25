using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMovement : MonoBehaviour
{
    // Variables
    public float rotationSpeed = 20f;
    public float deceleration = 10f;
    public float inputV;
    public float inputH;
    public float minRot = -10f;
    public float maxRot = 10f;
    public const float yRot = 0;

    private Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 2;
        rigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Call deceleration and rotation
       
        Rotation();
        Decelerate();
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, yRot, transform.eulerAngles.z);
    }

    void FixedUpdate()
    {
        rigid.AddForce(0, 0, -50);
    }

    void Decelerate()
    {
        // Activates deceleration
        rigid.velocity += -rigid.velocity * deceleration * Time.deltaTime;
    }

    void Rotation()
    {
        inputV = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        inputH = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Rotate(-inputV, 0, 0);
        transform.Rotate(0, 0,inputH);

        //Vector3 currentRotation = transform.localRotation.eulerAngles;
        //currentRotation.x = Mathf.Clamp(currentRotation.x, minRot, maxRot);
        //currentRotation.z = Mathf.Clamp(currentRotation.z, minRot, maxRot);
        //transform.localRotation = Quaternion.Euler(currentRotation);


    }
}
