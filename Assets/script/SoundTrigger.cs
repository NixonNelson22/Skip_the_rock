using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface ISoundTrigger{
    void ContinousSounds();
    void TriggeredSounds();
}
public class SoundTrigger : MonoBehaviour, ISoundTrigger
{
    // This class listens for a trigger to play the particular sound
    // sound clips
    [SerializeField] private AudioClip[] _rockClips;
    [SerializeField] private AudioClip[] _forestClips;
    [SerializeField] private AudioClip[] _frogClips;
    [SerializeField] private AudioClip[] _fishClips;
    [SerializeField] private AudioClip[] _lakeRockClips;
    

    // sound sources
    [SerializeField] private AudioSource _rockSource;
    [SerializeField] private AudioSource _forestSource;
    [SerializeField] private AudioSource _frogSource;
    [SerializeField] private AudioSource _lakeRockSource;

    
    void ContinousSounds(AudioSource aS,AudioClip[] aC){
        
        while(true){
            aS.clip = aC[UnityEngine.Random.Range(0,aC.Length)];
            aS.Play();
        }

    }
    void ISoundTrigger.continousSounds()
    {
        throw new System.NotImplementedException();
    }

    void TriggeredSounds(){
        
    }
    void ISoundTrigger.triggeredSounds()
    {
        throw new System.NotImplementedException();
    }
}

