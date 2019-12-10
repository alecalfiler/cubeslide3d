using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFx : MonoBehaviour
{

  public AudioSource myFx;
  public AudioClip clickFx;

  public void ClickSound()
  {
    myFx.PlayOneShot(clickFx);
  }

    public void quitGame()
    {
        Debug.Log("Application Shutting Down..");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
