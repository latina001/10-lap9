using UnityEngine;
using UnityEngine.InputSystem;

public class Airplane : MonoBehaviour
{
    public float enginePower = 20f;
    public float liftBooter = 0.5f;
    public float drang = 0.001f;
    public float angularDrag = 0.001f;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            rb.AddForce(transform.forward * enginePower);

            //lift
            Vector3 life = Vector3.Project(rb.linearVelocity, transform.forward);
            rb.AddForce(transform.up * life.magnitude * liftBooter);

            //Drag
            rb.linearDamping = rb.linearVelocity.magnitude * drang;
            rb.linearDamping = rb.linearVelocity.magnitude * angularDrag;
        }
    }
}
