using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float torque = 10f;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float boostSpeed = 10f;

    [SerializeField] float normalSpeed = 5f;
    public bool check = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    void Update()
    {
        if(check)
        {
            Rotate();
            BoostSpeed();
        }
        else
        {
            StopMove();
        }      
    }
    public void StopMove()
    {
        check = false;
    }
    void BoostSpeed()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }
    void Rotate()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            rb.AddTorque(torque);
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            rb.AddTorque(-torque);
        }
    }

}
