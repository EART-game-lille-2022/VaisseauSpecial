using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudoiManager : MonoBehaviour
{
    public static AudoiManager instance;
    public AudioSource _source;

    public static AudioClip CANNON_SHOOT;
    public static AudioClip OVERHEAT_ALARM;
    public static AudioClip MOTOR_ALARM;
    public static AudioClip AIM_BUTTON;
    public static AudioClip SCREEN_NOTIFICATION;
    public static AudioClip VENTILATION;

    void Awake()
    {
        instance = this;
    }

    public void SFX(AudioClip toPlay)
    {

    }
}
