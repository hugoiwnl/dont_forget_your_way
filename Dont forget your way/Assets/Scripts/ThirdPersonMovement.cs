using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public SpriteRenderer spriteBehindRenderer;
    public SpriteRenderer spirteRightRenderer;
    public SpriteRenderer spriteFrontRenderer;

    public bool cringe = true;

    void Start()
    {
        // StartCoroutine("DoCheck");
        // CinemachineShake.Instance.ShakeCamera(3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CinemachineShake.Instance.StopShakeCamera();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            CinemachineShake.Instance.ShakeCamera(5f);
        }

        if (cringe)
        {
            StartCoroutine("DoCheck");
            cringe = false;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        // camera stays with character
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        
        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (horizontal > 0 || horizontal < 0)
        {
            spriteBehindRenderer.enabled = false;
            spirteRightRenderer.enabled = true;
            spriteFrontRenderer.enabled = false;


            if (spirteRightRenderer.flipX && horizontal < 0)
            {
                spriteBehindRenderer.flipX = true;
            }
            else if (!spriteBehindRenderer.flipX && horizontal > 0)
            {
                spriteBehindRenderer.flipX = false;
            }
        } else if (vertical < 0) {
                spriteFrontRenderer.enabled = true;
                spriteBehindRenderer.enabled = false;
                spirteRightRenderer.enabled = false;

            } else if (vertical > 0)
            {
                spriteBehindRenderer.enabled = true;
                spirteRightRenderer.enabled = false;
                spriteFrontRenderer.enabled = false;

            }   
        else
        {
            spriteBehindRenderer.enabled = false;
            spirteRightRenderer.enabled = false;
            spriteFrontRenderer.enabled = true;
        }
    }

    IEnumerator DoCheck()
    {
        for (;;)
        {
            // execute block of code here
            CinemachineShake.Instance.ShakeCamera(0.5f) ;

            yield return new WaitForSeconds(1f);
        }
    }
}
