using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private  InputReader inputReader;
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private Rigidbody2D rb;

    [Header("Settings")]
    [SerializeField] private float movementSpeed = 4f;
    [SerializeField] private float turningRate = 30f;
    private Vector2 previousMovementInput;

    public override void OnNetworkSpawn()
    {
        if(!IsOwner){return;}

        inputReader.MoveEvent += HandleMove;
    }

    public override void OnNetworkDespawn()
    {
        inputReader.MoveEvent -= HandleMove;
    }

    private void Update()
    {
        if(!IsOwner){return;}

        float ZRotation = previousMovementInput.x * -turningRate * Time.deltaTime; // -turningRate because we want to turn left when pressing left
        bodyTransform.Rotate(0f, 0f, ZRotation);
    }

    private void FixedUpdate() 
    {
        if(!IsOwner){return;}

        rb.velocity = (Vector2)bodyTransform.up * movementSpeed * previousMovementInput.y;
    }

    private void HandleMove(Vector2 movementInput)
    {
        previousMovementInput = movementInput;
    }
}
