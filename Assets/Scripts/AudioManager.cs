using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  public static AudioManager singleton;
  
  public AudioClip[] clips;
  private AudioSource audioSource;

  private void Awake()
  {
    singleton = this;
    audioSource = GetComponent<AudioSource>();
  }

  public void PlaySound(int clipIndex)
  {
    audioSource.PlayOneShot(clips[clipIndex]);
  }
}
