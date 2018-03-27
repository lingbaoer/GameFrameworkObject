using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScoreCommand : EventCommand {

    [Inject]
    public IScoreService scoreService { get; set; }

    [Inject]
    public ScoreModel scoreModel { get; set; }
    public override void Execute()
    {
        Retain();
        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore, OnComplete);
        scoreService.RequestScore("http://xx/xxx/xxx");
    }

    public void OnComplete(IEvent evt)//IEvent存储参数
    {
        Debug.Log("Request score complete "+evt.data);
        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore, OnComplete);
        scoreModel.Score = (int)evt.data;
        dispatcher.Dispatch(Demo1MediatroEvent.ScoreChange, evt.data);

        Release();
    }
}
