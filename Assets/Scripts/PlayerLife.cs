using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]private AudioSource DeadAudio;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    public GameObject GameOverScreen;
    public GameObject Pausebutton;    

    public PlayerMovement movement;
    void Start()
    {
        _animator=GetComponent<Animator>();
        _rigidBody=GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Traps"))
        {
            StartCoroutine(Dead());
        }
    }
    IEnumerator Dead() 
    {
        DeadAudio.Play();
        _rigidBody.bodyType=RigidbodyType2D.Static;
        _animator.SetTrigger("Dead"); //play dead animation
        yield return new WaitForSeconds(1.5f);
        GameOverScreen.SetActive(true);
        Pausebutton.SetActive(false);
        Time.timeScale=0f;
        movement.enabled=true;
    }


}
