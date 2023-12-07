using System.Collections;
using TMPro;
using UnityEngine;

public class StandAloneTypewriter : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] TextMeshProUGUI textZone;
    private int count = 0;
    [SerializeField] float delay = 0.01f;
    public AudioClip space;
    public AudioClip letter;
    public float volume = 1;

    private void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if (textZone == null)
            textZone = GetComponent<TextMeshProUGUI>();
    }

    //todoC'est TypeText() qu'il faut appeler dans les autres codes pour créer un nouveau message
    public void TypeText(string newMessage)
    {
        //!je reset la zone de texte
        textZone.text = "";

        StartCoroutine(TypeDelay(newMessage, textZone));

    }

    //!la magiiiiiiiiiiiiieeee, je sais plus comment il finctionne exactement mais c'est censé marcher
    IEnumerator TypeDelay(string completeText, TextMeshProUGUI currentText)
    {

        float charCounter = 0;
        for (int i = 0; i < completeText.Length; i++)
        {
            charCounter++;
            currentText.text = completeText.Substring(0, i);
            if (i > 0 && currentText.text.Substring(currentText.text.Length - 1) == " ")
                PlaySound(space);
            else if (charCounter % 2 > 1)
            {
                PlaySound(letter);
                charCounter = 0;
            }
            yield return new WaitForSeconds(delay);
        }

        currentText.text = completeText;
        count += 1;
    }

    public void PlaySound(AudioClip soundName)
    {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(soundName, volume);
    }
}
