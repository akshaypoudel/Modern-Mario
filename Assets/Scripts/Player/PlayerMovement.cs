using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    #region UIReferences
        public TMP_Text strawBerryText; 
        public TMP_Text coinText; 
    #endregion

    #region VariableReferences
        [HideInInspector]
        public bool isGrounded;
        private int strawberryCount;
        private int coinCount;

        private int maxJumps = 2;
        private int jumpsCount;

        public static float currentDirection;
        public float runSpeed;
        public int jumpHeight;
        public static bool canRun=true;
        public static bool canJump=true;
    #endregion
    #region ComponentReferences
        private Rigidbody2D _rigidBody;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

    #endregion

    private int isJumping = Animator.StringToHash("isJumping");
    private int isRunning = Animator.StringToHash("isRunning");
    private int isDoubleJumping = Animator.StringToHash("isDoubleJumping");

    private string ground = "Ground";
    private string strawBerryString = "Strawberry";
    private string coinString = "Coin";


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();   
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MovePlayer();
        CheckIfJumpButtonPressed();
    }


    private void CheckIfJumpButtonPressed()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("AButton"))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (jumpsCount == 0) return;
        if(jumpsCount==1)
        {
            _animator.SetTrigger(isDoubleJumping);
        }
        if( jumpsCount > 0)
        {
            SoundManager.PlaySound(SoundManager.Sound.Jump);
            isGrounded=false;
            _rigidBody.velocity=Vector2.up * jumpHeight;
            _animator.SetBool(isJumping,true);
            jumpsCount--;
        }
    }
    private void MovePlayer()
    {
#if UNITY_EDITOR
        float HMovement=Input.GetAxis("Horizontal");
#else
        float HMovement = currentDirection;
#endif
        HMovement *= runSpeed;
        if (HMovement>0)
        {
            FlipPlayerSprite(false);
            AnimatePlayer(true);
        }
        else if(HMovement<0)
        {
            FlipPlayerSprite(true);
            AnimatePlayer(true);
        }
        else 
        {
            AnimatePlayer(false);
        }
        _rigidBody.velocity=new Vector2(HMovement,_rigidBody.velocity.y);

    }

    private void FlipPlayerSprite(bool canFlip)
    {
        _spriteRenderer.flipX = canFlip;
    }

    private void AnimatePlayer(bool running)
    {
        _animator.SetBool(isRunning, running);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag(strawBerryString))
        {
            SoundManager.PlaySound(SoundManager.Sound.CollectItem);

            strawberryCount++;
            strawBerryText.text=strawberryCount.ToString();
            Destroy(other.gameObject);
        }        
        if(other.gameObject.CompareTag(coinString))
        {
            SoundManager.PlaySound(SoundManager.Sound.CollectItem);

            coinCount++;
            coinText.text=coinCount.ToString();
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag(ground) && !this.gameObject.CompareTag("PlayerCollider"))
        {
            isGrounded=true;
            jumpsCount = maxJumps;
            _animator.SetBool(isJumping,false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
