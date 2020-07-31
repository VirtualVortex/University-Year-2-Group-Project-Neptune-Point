using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AnxietyAudio : MonoBehaviour
{
    [SerializeField]
    float fadeTime;
    [SerializeField]
    float delay;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField, Tooltip("Make the last element the default snapshot")]
    AudioMixerSnapshot[] audioSnapshots;

    Slider anxietyBar;
    bool runOnce;
    int randomSnapShot;

    // Start is called before the first frame update
    void Start()
    {
        anxietyBar = GameObject.Find("Slider").GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anxietyBar.value > 0.5f)
        {
            if (!runOnce)
            {
                randomSnapShot = Random.Range(0, audioSnapshots.Length - 1);
                Debug.Log("Run once: " + randomSnapShot);
                runOnce = true;
            }

            RandomAudioScreenShot();
        }


        if (anxietyBar.value < 0.5f)
        {
            DefaultAudioScreenshot();
            runOnce = false;
        }
    }

    void RandomAudioScreenShot() 
    {
        audioSnapshots[randomSnapShot].TransitionTo(fadeTime);
    }

    void DefaultAudioScreenshot() 
    {
        audioSnapshots[audioSnapshots.Length - 1].TransitionTo(fadeTime);
    }
}
