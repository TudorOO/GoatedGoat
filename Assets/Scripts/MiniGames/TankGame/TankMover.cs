using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    public Rigidbody2D rb2d;

    private Vector2 movementVector;

    public float acceleration = 70;
    public float deacceleration = 50;
    public float currentSpeed = 0;
    public float currentForwardDirection = 1;

    public float maxSpeed = 10;
    public float rotationSpeed = 100;
    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector){
        this.movementVector = movementVector;

        CalculateSpeed(movementVector);
        if(movementVector.y > 0){
            currentForwardDirection = 1;
        }else if(movementVector.y < 0){
            currentForwardDirection = -1;
        }
    }

    private void CalculateSpeed(Vector2 movementVector){
        if(Mathf.Abs(movementVector.y) > 0){
            currentSpeed += acceleration * Time.deltaTime;
        }else{
            currentSpeed -= deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up * currentSpeed * currentForwardDirection * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }

}
