using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //float move = Input.GetAxis("Vertical");

        

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 velocity = movement * speed;
        GetComponent<Rigidbody>().velocity = velocity;

        anim.SetFloat("Speed", speed);


        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(jumpHash);
        }
        
    }
}
