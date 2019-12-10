using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

  public static AudioClip Crash;
  static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        Crash = Resources.Load<AudioClip> ("Crash");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {


    }


    public static void PlaySound (string clip)
    {
      switch (clip)
      {
        case "crash":
          audioSrc.PlayOneShot(Crash);
          break;
      }
    }
}
