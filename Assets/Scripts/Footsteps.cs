using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour

{
    CharacterController cc;
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
     if(cc.isGrounded && cc.velocity.magnitude > 2f && audio.isPlaying == false)
        {
            audio.Play();
        }   
    }
}
