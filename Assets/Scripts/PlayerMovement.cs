using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    #region UIReferences
        public TMP_Text UIText; 
    #endregion

    #region VariableReferences
        [HideInInspector]
        public bool isGrounded;
        // private float horizotalMove;
        private int pineApple;
        public float runSpeed;
        public int jumpHeight;
        [HideInInspector] public static bool canRun=true;
        [HideInInspector] public static bool canJump=true;
    #endregion

    #region ComponentReferences
        private Rigidbody2D _rigidBody;
        [HideInInspector]
        public Animator _animator;
        private SpriteRenderer _renderer;
        [SerializeField] private AudioSource JumpAudio;
        [SerializeField] private AudioSource CollectAudio;

        

    #endregion

    void Start()
    {
        _rigidBody=GetComponent<Rigidbody2D>();
        _animator=GetComponent<Animator>();
        _renderer=GetComponent<SpriteRenderer>();  
        CollectAudio.playOnAwake=false;
    }

    private void Update()
    {
        #if UNITY_EDITOR
            MovePlayer();
        #elif UNITY_ANDROID
            MovePlayer1();
        #endif
        Jump();
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpAudio.Play();
            isGrounded=false;
            _rigidBody.velocity=Vector2.up*jumpHeight;
            _animator.SetBool("isJumping",true);
        }
    }
    private void MovePlayer()
    {
        float HMovement=Input.GetAxis("Horizontal")*runSpeed;
        if(HMovement>0)
        {
            _renderer.flipX=false;
            _animator.SetBool("isRunning",true);
        }
        else if(HMovement<0)
        {
            _renderer.flipX=true;
            _animator.SetBool("isRunning",true);
        }
        else 
        {
            _animator.SetBool("isRunning",false);
        }
        _rigidBody.velocity=new Vector2(HMovement,_rigidBody.velocity.y);

    }

    private void MovePlayer1()
    {
        float HMovement=CrossPlatformInputManager.GetAxis("Horizontal")*runSpeed;
        if(HMovement>0)
        {
            _renderer.flipX=false;
            _animator.SetBool("isRunning",true);
        }
        else if(HMovement<0)
        {
            _renderer.flipX=true;
            _animator.SetBool("isRunning",true);
        }
        else 
        {
            _animator.SetBool("isRunning",false);
        }
        _rigidBody.velocity=new Vector2(HMovement,_rigidBody.velocity.y);

    }


    ///*//////****////////////////////////////////////////////////////////////////////////////////////////////
    //Colliding Functions

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Collectibles"))
        {
            CollectAudio.Play();
            pineApple++;
            UIText.text=pineApple.ToString();
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded=true;
            _animator.SetBool("isJumping",false);
        }
    }





























}
