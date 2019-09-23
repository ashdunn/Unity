using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class SimpleMovement : MonoBehaviour
{

    public float Speed;
    public float RotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        transform.Rotate(0, Input.GetAxis("Horizontal") * RotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        float curSpeed = Speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }
}
