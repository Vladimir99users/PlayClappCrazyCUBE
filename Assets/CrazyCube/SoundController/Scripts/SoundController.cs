using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    private AudioSource _mainSource => GetComponent<AudioSource>();

    public static UnityAction<AudioClip> OnEnableSoundEffect;

    private void OnEnable()
    {
        OnEnableSoundEffect += PlayOneShotClip;
    }

    private void OnDisable()
    {
        OnEnableSoundEffect -= PlayOneShotClip;
    }

    public void PlayOneShotClip(AudioClip clip)
    {
        _mainSource.PlayOneShot(clip);
    }
    
}
