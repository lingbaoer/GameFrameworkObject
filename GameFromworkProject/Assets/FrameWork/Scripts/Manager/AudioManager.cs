using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    //static 静态   const 常量
    private static string audioTextPathPrefix = Application.dataPath+"\\FrameWork\\Resources\\";
    private const string audioTextPathMiddle = "AudioList";
    private const string audioTextPathPostfix = ".txt";

    private Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();

    public bool isMute = false;

    public static string AudioTextPath
    {
        get
        {
            return audioTextPathPrefix + audioTextPathMiddle+ audioTextPathPostfix;
        }
    }

    public void Init()
    {
        LoadAudioClip();
    }

    private void LoadAudioClip()
    {
        audioClipDict = new Dictionary<string, AudioClip>();
        TextAsset ta = Resources.Load<TextAsset>(audioTextPathMiddle);
        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] keyvalue = line.Split(',');
            string key = keyvalue[0];
            AudioClip value = Resources.Load<AudioClip>(keyvalue[1]);
            audioClipDict.Add(key,value);
        }
    }

    public void Play(string name)
    {
        if (isMute) return;
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, Vector3.zero);
        }
    }

    public void Play(string name, Vector3 position)
    {
        if (isMute) return;
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, position);
        }
    }
}
