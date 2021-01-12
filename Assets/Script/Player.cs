using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 4f;
    [SerializeField] float xRange = 4.5f;
    [SerializeField] float yRange = 3f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -10f;

    float xThrow, yThrow;

    [Space]

    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this function handles the movements
        HandleMovement();

        //this function handles the rotation
        HandleRotation();
    }

    void HandleRotation()
    {
        float pitch = (transform.localPosition.y * positionPitchFactor) + (yThrow * controlPitchFactor);
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void HandleMovement()
    {
        //x axis movement
        xThrow = Input.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset; 
        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        //y axis movement
        yThrow = Input.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset; 
        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        //applies the position
        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);     
    }
}
