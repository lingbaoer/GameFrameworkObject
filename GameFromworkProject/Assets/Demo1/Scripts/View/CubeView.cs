﻿using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    [Inject]
    public AudioManager audioManager { get; set; }

    private Text scoreText;

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        scoreText = GetComponentInChildren<Text>();

    }

    private void Update()
    {
        transform.Translate(new Vector3(Random.Range(-1,2),Random.Range(-1, 2),Random.Range(-1, 2))*0.2f);

        if (Input.GetMouseButtonDown(0))
        {
            PoolManager.Instance.GetInst("Bullet");
        }
    }

    private void OnMouseDown()
    {
        //加分
        Debug.Log("OnMouseDown");
        audioManager.Play("button");
        dispatcher.Dispatch(Demo1MediatroEvent.ClickDown);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
