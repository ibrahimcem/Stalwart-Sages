using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllers : MonoBehaviour
{
    Animator animator;

    public CharacterController controller;
    public float speed = 2f;
    public FixedJoystick fixedJoystick;
    private void Start()
    {
        animator = GetComponent<Animator>();

    }
    private void LateUpdate()
    {
        float horizontal = fixedJoystick.Horizontal;
        float vertical = -fixedJoystick.Vertical;
        Vector3 direction = new Vector3(vertical, -1f, horizontal);
        Vector3 direction2 = new Vector3(vertical, 0f, horizontal);

        if (direction2.magnitude >= 0.1f)
        {
            animator.SetInteger("walk", 1);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
        else
        {
            controller.Move(direction * speed * Time.deltaTime);
            animator.SetInteger("walk", 0);
        }

    }
}
