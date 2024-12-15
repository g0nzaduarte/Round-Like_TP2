using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ServiceLocator
{
    private static IAudioService audioService;

    public static IAudioService AudioService => audioService;

    public static void ProvideAudioService(IAudioService service)
    {
        audioService = service;
    }
}

public interface IAudioService
{
    void PlaySound(string soundName);
}
