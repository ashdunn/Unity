using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class SimpleMovement : MonoBehaviour
{

    public float Speed = 1.5f;
    public float RotateSpeed;
    Animator anim;
    public float runSpeed = 8.0f;
    public float walkSpeed = 1.5f;
    private bool running = false;

    int runHash = Animator.StringToHash("Running");
    int walkHash = Animator.StringToHash("Walking");


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger(walkHash);
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        float v = Input.GetAxis("Vertical");
        //speed for movement
        anim.SetFloat("Walk", v);

        transform.Rotate(0, Input.GetAxis("Horizontal") * RotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        float curSpeed = Speed * v;
        controller.SimpleMove(forward * curSpeed);

        //switch between walking and running
        if(Input.GetButtonDown("Fire1"))
        {
            if (!running)
            {
                
                anim.SetBool("Running", true);
                running = true;
                Speed = runSpeed;
               
            }
            else
            {
                running = false;
                anim.SetBool("Running", false);
                Speed = walkSpeed;
            }
        }
        //keep switch speed back if it was reset for backwards
        if (running && Input.GetKey(KeyCode.W))
            Speed = runSpeed;
        //don't run backwards
        if (Input.GetKey(KeyCode.S))
        {
            Speed = walkSpeed;
        }

        if (Input.GetKey(KeyCode.A))
            anim.SetTrigger("LeftTurn");
        if (Input.GetKey(KeyCode.D))
            anim.SetTrigger("RightTurn");


        if (Input.GetButtonDown("Jump"))
            anim.SetTrigger("Jump");

    }
}
