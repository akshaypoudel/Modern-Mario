using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField] private GameObject Player;
    public GameObject GameOverScreen;
    private void Start() {
        player=GameObject.FindWithTag("Player").transform;
    }

    private void Update() {
        transform.position=new Vector3(player.position.x,
                                       player.position.y+0.5f,
                                       transform.position.z);    
    }
    private void FixedUpdate() {
        if(Player.transform.position.y < -18f)
        {
            Debug.Log("GameOver");
            GameOverScreen.SetActive(true);
            Time.timeScale=0f;
        }
    }
}
