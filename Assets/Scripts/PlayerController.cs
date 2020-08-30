using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed;

    private Vector2 moveInput;

    public Animator anim, flipAnim;
    public SpriteRenderer sr;

    private bool movingBackwards;

    public Transform camTarget;
    public float aheadAmount, aheadSpeed;

    public bool canInteract;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);

        anim.SetFloat("moveSpeed", rb.velocity.magnitude);

        // Sprite Flip
        if (!sr.flipX && moveInput.x < 0f)
        {
            sr.flipX = true;
            //flipAnim.SetTrigger("Flip");
        }
        else if (sr.flipX && moveInput.x > 0f)
        {
            sr.flipX = false;
            //flipAnim.SetTrigger("Flip");
        }

        if (!movingBackwards && moveInput.y > 0f)
        {
            movingBackwards = true;
            //flipAnim.SetTrigger("Flip");
        }
        else if (movingBackwards && moveInput.y < 0f)
        {
            movingBackwards = false;
            //flipAnim.SetTrigger("Flip");
        }

        anim.SetBool("movingBackwards", movingBackwards);

        // Cam Target Look Ahead
        if (Input.GetAxisRaw("Horizontal") != 0f)
        {
            camTarget.localPosition = new Vector3(Mathf.Lerp(camTarget.localPosition.x, aheadAmount * Input.GetAxisRaw("Horizontal"), aheadSpeed * Time.deltaTime), camTarget.localPosition.y, camTarget.localPosition.z);
        }

        if (Input.GetAxisRaw("Vertical") != 0f)
        {
            camTarget.localPosition = new Vector3(camTarget.localPosition.x, camTarget.localPosition.y, Mathf.Lerp(camTarget.localPosition.z, aheadAmount * Input.GetAxisRaw("Vertical"), aheadSpeed * Time.deltaTime));
        }
    }
}
