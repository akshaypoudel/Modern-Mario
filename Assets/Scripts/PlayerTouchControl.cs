using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTouchControl : MonoBehaviour
{
        public Button leftButton;
        public Button rightButton;
        public Button jumpButton;
        private SpriteRenderer _renderer;
        private Animator _animator;
        private PlayerMovement movement;
        private Rigidbody2D _rigidBody;
        public AudioSource jumpAudio;

        
        private bool moveLeft;
        private bool moveRight;
        [SerializeField]
        private int runSpeed;
    // Start is called before the first frame update
    void Start()
    {
        jumpButton.onClick.AddListener(JumpButton);  
        _animator=GetComponent<Animator>(); 
        _rigidBody=GetComponent<Rigidbody2D>();  
        _renderer=GetComponent<SpriteRenderer>();
        movement=GetComponent<PlayerMovement>();   
    }

    private void JumpButton()
    {
        if(movement.isGrounded)
        {
            jumpAudio.Play();
            movement.isGrounded=false;
            _rigidBody.velocity=Vector2.up*movement.jumpHeight;
            _animator.SetBool("isJumping",true);
        }
    }















}
