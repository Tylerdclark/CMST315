using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround;
    public bool gameOver;

    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");
    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        //inverting the if block to reduce nesting (ide told me to)
        if (!Input.GetKeyDown(KeyCode.Space) || !isOnGround || gameOver) return;
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        playerAnim.SetTrigger(JumpTrig);
        dirtParticle.Stop();
        playerAudio.PlayOneShot(jumpSound, 1.0f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            gameOver = true;
            Debug.Log("Game over!");
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAnim.SetBool(DeathB, true);
            playerAnim.SetInteger(DeathTypeINT, 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
            
        }
    }
}
