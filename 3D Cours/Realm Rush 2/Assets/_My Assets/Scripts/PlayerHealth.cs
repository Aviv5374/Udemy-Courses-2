using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthTXT;
    [SerializeField] AudioClip playerDamageSFX;

    AudioSource myAudioSource;

    void Start()
    {
        healthTXT.text = health.ToString();
        myAudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease;
        healthTXT.text = health.ToString();
        myAudioSource.PlayOneShot(playerDamageSFX);
    }
}
