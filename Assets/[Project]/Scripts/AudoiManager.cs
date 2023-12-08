using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudoiManager : MonoBehaviour
{
    public static AudoiManager instance;
    public AudioSource _source;

    public AudioClip CANNON_SHOOT;
    public AudioClip OVERHEAT_ALARM;
    public AudioClip MOTOR_ALARM;
    public AudioClip AIM_BUTTON;
    public AudioClip SCREEN_NOTIFICATION;
    public AudioClip VENTILATION;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void SFX(AudioClip toPlay)
    {
        _source.PlayOneShot(toPlay);
    }
}
