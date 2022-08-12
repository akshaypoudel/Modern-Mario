using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public GameObject LevelCompleted;
    public GameObject Player;
    public AudioSource BGMusic;
    public GameObject Pausebutton;
    bool isCollided=false;


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
        SoundManager.PlaySound(SoundManager.Sound.Finish);
        yield return new WaitForSeconds(0.8f);
        LevelCompleted.SetActive(true);
        Pausebutton.SetActive(false);
        Time.timeScale=0f;
        isCollided=false;
    }

}
