using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float Speed = 1.0f;
    public float RotationSpeed = 1.0f;
    public float JumpForce = 1.0f;
    private Animator anim;
    private Rigidbody Physics;
    public float x, y;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Physics = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento 
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime * RotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * Speed);

        //Rotacion de la camara
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));

        //Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }

        //Animaciones
        anim.SetFloat("Vel X", x);
        anim.SetFloat("Vel Y", y);

    }
}
