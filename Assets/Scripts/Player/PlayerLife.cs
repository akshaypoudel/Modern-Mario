using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator _animator;
    public GameObject GameOverScreen;
    public GameObject Pausebutton;
    private string Traps = "Traps";
    private int dead = Animator.StringToHash("Dead");
    void Start()
    {
        _animator=GetComponent<Animator>();
    }
    private void Update()
    {
        CheckGameOver();
    }
    private void CheckGameOver()
    {
        if (transform.position.y < -30f)
        {
            StartCoroutine(Dead());
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag(Traps) && !this.gameObject.CompareTag("PlayerCollider"))
        {
            StartCoroutine(Dead());
        }
    }
    IEnumerator Dead()
    {
        SoundManager.PlaySound(SoundManager.Sound.Dead);
        DisableComponents();
        _animator.SetTrigger(dead); //play dead animation
        yield return new WaitForSeconds(1.5f);

        GameOverScreen.SetActive(true);
        Pausebutton.SetActive(false);

        Time.timeScale = 0f;

    }

    private void DisableComponents()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<PlayerLife>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }
}
