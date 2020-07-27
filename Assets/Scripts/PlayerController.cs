using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed, jumpForce;

    private Vector2 moveInput;

    public LayerMask ground;
    public Transform groundChecker;
    private bool isGrounded;

    public Animator anim, flipAnim;
    public SpriteRenderer sr;

    private bool movingBackwards;

    public float hangTime;
    private float hangCounter;

    public float jumpBufferLength;
    private float jumpBufferCounter;

    public ParticleSystem footstepsEffect, impactEffect;
    public ParticleSystem.EmissionModule footEmission;
    private bool wasOnGround;

    public Transform camTarget;
    public float aheadAmount, aheadSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        footEmission = footstepsEffect.emission;
    }

    void Update()
    {
        // Movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);

        anim.SetFloat("moveSpeed", rb.velocity.magnitude);

        // Ground Check
        RaycastHit hit;
        if (Physics.Raycast(groundChecker.position, Vector3.down, out hit, .3f, ground))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Jump
        if (isGrounded)
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferLength;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter >= 0f && hangCounter > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            jumpBufferCounter = 0f;

            /*impactEffect.gameObject.SetActive(true);
            impactEffect.Stop();
            impactEffect.transform.position = footstepsEffect.transform.position;
            impactEffect.Play();*/
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * .5f, rb.velocity.z);
        }

        anim.SetBool("onGround", isGrounded);

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

        // Footprint and Impact Effects
        if (isGrounded && Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
            footEmission.rateOverTime = 35f;
        }
        else
        {
            footEmission.rateOverTime = 0f;
        }
        
        if (!wasOnGround && isGrounded)
        {
            impactEffect.gameObject.SetActive(true);
            impactEffect.Stop();
            impactEffect.transform.position = footstepsEffect.transform.position;
            impactEffect.Play();
        }

        wasOnGround = isGrounded;

        // Cam Target Look Ahead
        if (Input.GetAxisRaw("Horizontal") != 0f)
        {
            camTarget.localPosition = new Vector3(Mathf.Lerp(camTarget.localPosition.x, aheadAmount * Input.GetAxisRaw("Horizontal"), aheadSpeed * Time.deltaTime), camTarget.localPosition.y, camTarget.localPosition.z);
        }

        if (Input.GetAxisRaw("Vertical") != 0f)
        {
            camTarget.localPosition = new Vector3(camTarget.localPosition.x, camTarget.localPosition.y, Mathf.Lerp(camTarget.localPosition.z, aheadAmount * Input.GetAxisRaw("Vertical"), aheadSpeed * Time.deltaTime));
        }

        // Sprint
        if (Input.GetButton("Sprint") && isGrounded)
        {
            moveSpeed = 15f;
        }
        else
        {
            moveSpeed = 10f;
        }

    }
}
