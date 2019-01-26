using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float attackSpeed = .5f;
    public float lastAttack;

    Camera viewCamera;
    Rigidbody rb;

    Vector3 moveVelocity;

    void Start()
    {
    }


    void Awake()
    {
        viewCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement input

        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (moveInput.magnitude < .35f) {
            moveInput = new Vector3();
        }
        moveVelocity = moveInput.normalized * moveSpeed;
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        //// Look input
        //Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        //Plane groundPlane = new Plane(Vector3.up, Vector3.up);
        //float rayDistance;

        //if (groundPlane.Raycast(ray, out rayDistance)) {
        //    Vector3 point = ray.GetPoint(rayDistance);
        //    Debug.DrawLine(ray.origin, point, Color.red);
        //}

        //Attacks
        if (Input.GetMouseButton(0)) {
            if (Time.time - lastAttack > attackSpeed) {
                lastAttack = Time.time;

            }
        }
    }
}
