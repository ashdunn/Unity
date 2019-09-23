using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Animator anim;

    public float MaxSpeed = 3;
    public float RotateSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim == null)
            return;

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        Move(x, y);
    }

    private void Move(float x, float y)
    {
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        //transform.position += Vector3.forward * MaxSpeed * y * Time.deltaTime;
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        float curSpeed = MaxSpeed * y;
        controller.SimpleMove(forward * curSpeed);
        transform.Rotate(0, x * RotateSpeed, 0);

        anim.SetFloat("AngSpeed", x * RotateSpeed);

    }
}
