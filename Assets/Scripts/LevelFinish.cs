using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public GameObject LevelCompleted;
    public GameObject Player;
    public AudioSource FinishAudio;
    public AudioSource BGMusic;
    Rigidbody2D _rigidbody;
    public GameObject Pausebutton;
    bool isCollided=false;

    private void Start() {
        FinishAudio=GetComponent<AudioSource>();
        _rigidbody=Player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("Player") && !isCollided)
        {
            StartCoroutine(FinishLevel());
        }
    
    }

    IEnumerator FinishLevel()
    {
        isCollided=true;
        BGMusic.Stop();
        //Debug.Log("Level Completed: ");
        FinishAudio.Play();
        // _rigidbody.bodyType=RigidbodyType2D.Static;
        yield return new WaitForSeconds(1f);
        LevelCompleted.SetActive(true);
        Pausebutton.SetActive(false);
        Time.timeScale=0f;
        isCollided=false;
    }

}
