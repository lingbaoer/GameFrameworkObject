﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager
{
    private static LocalizationManager _instance;
    public static LocalizationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LocalizationManager();
            }
            return _instance;
        }
    }

    private const string Chinese = "Localization/Chinese";
    private const string English = "Localization/English";

    public const string Language = English;

    private Dictionary<string, string> dict = new Dictionary<string, string>();

    private LocalizationManager()
    {
        dict = new Dictionary<string, string>();

        TextAsset ta=Resources.Load<TextAsset>(Language);
        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line) == false)
            {
                string[] keyvalues = line.Split('=');
                dict.Add(keyvalues[0],keyvalues[1 ]);
            }
        }
    }

    public void Init()
    {
        //no thing
    }

    public string GetValue(string key)
    {
        string value;
        dict.TryGetValue(key, out value);
        return value;
    }

}
