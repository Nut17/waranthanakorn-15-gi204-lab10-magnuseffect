using UnityEngine;
using UnityEngine.InputSystem;

public class A : MonoBehaviour
{
    public float enginePower = 20f;
    public float liftBooster = 0.5f;
    public float drag = 0.01f;
    public float angularDrag = 0.01f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float yawPower = 50f;
    public float pitchPower = 50f;
    public float rollPower = 25f;

    void FixedUpdate()
    {
        if (Keyboard.current.spaceKey.isPressed)
        { 
           rb.AddForce(transform.forward * enginePower);
        }

        Vector3 lift = Vector3.Project(rb.linearVelocity,transform.forward );
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;

        float yaw = (Keyboard.current.qKey.isPressed ? 1f : 0f) - (Keyboard.current.eKey.isPressed ? 1f : 0f);
        yaw *= yawPower;

        float pitch = (Keyboard.current.sKey.isPressed ? 1f : 0f) - (Keyboard.current.wKey.isPressed ? 1f : 0f);
        pitch *= pitchPower;

        float roll = (Keyboard.current.aKey.isPressed ? 1f : 0f) - (Keyboard.current.dKey.isPressed ? 1f : 0f);
        roll *= rollPower;

        rb.AddTorque(transform.up * yaw);
        rb.AddTorque(transform.right * pitch);
        rb.AddTorque(transform.forward * roll);
    }
}
