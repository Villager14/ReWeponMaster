using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAudio : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip playerSordAtk;

    public AudioClip becase1;
    public AudioClip becase2;
    public AudioClip becase3;
    public AudioClip becase4;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void SourdSwing()
    {
        audioSource.PlayOneShot(playerSordAtk);
    }

    public void Because(int i)
    {
        switch (i)
        {
            case 0:
                audioSource.PlayOneShot(becase1);
                break;
            case 1:
                audioSource.PlayOneShot(becase2);
                break;
            case 2:
                audioSource.PlayOneShot(becase3);
                break;
            case 3:
                audioSource.PlayOneShot(becase4);
                break;
        }
    }
}
