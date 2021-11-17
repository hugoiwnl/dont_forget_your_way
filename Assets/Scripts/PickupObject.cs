using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    // public AudioSource audio;

    private void Start()
    {
        // audio = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // audio.Play();
            
            Destroy(gameObject);
            CinemachineShake.Instance.StopShakeCamera();


        }
    }
}
