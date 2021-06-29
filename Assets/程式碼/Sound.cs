using UnityEngine;
using System.Collections.Generic;
using System.Collections;//�ޥΨt�ζ��X�B�޲zAPI(��P�{��:�D�P�B�B�z)

public class Sound : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip kingsound;
    public AudioClip kingbgm;
    public bool play = false;


    public void Update()
    {
        if(play ==false)
        {
            StartCoroutine(KingSound());
        }
    }
    public IEnumerator KingSound()
    {
        if(LVsave.boosspawn == true)
        {
            play = true;
            aud.PlayOneShot(kingsound);
            yield return new WaitForSeconds(1f);
            if(LVsave.finalboss == true)
            {
                aud.clip = kingbgm;
                aud.Play();
            }          
        }
    }

}
