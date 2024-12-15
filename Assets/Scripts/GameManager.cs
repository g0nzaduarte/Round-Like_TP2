using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioService audioService;

    private void Awake()
    {
        ServiceLocator.ProvideAudioService(audioService);
    }
}

