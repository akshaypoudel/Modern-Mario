using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private Animator _animator;

    private void Start() {
        _animator=GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("FireOff",true);
            this.gameObject.tag="Ground";
        }
    }
}
