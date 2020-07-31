using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFootStepAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] footSteps;

    private AudioSource audioSource;
    private PlayerMovement pm;
    private int rightFoot;
    private int leftFoot;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pm = GetComponent<PlayerMovement>();
    }

    void RightFoot()
    {
        if(!pm.inAir)
        {
            rightFoot = Random.Range(0,1);
            audioSource.clip = footSteps[rightFoot];
            audioSource.Play();
        }
    }

    void LeftFoot()
    {
        if(!pm.inAir)
        {
            leftFoot = Random.Range(2,4);
            audioSource.clip = footSteps[leftFoot];
            audioSource.Play();
        }
    }
}
