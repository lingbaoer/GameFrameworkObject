using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMediator : Mediator
{
    [Inject]
    public CubeView cubeView { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]//全局的Dispatcher
    public IEventDispatcher dispatcher { get; set; }

    public override void OnRegister()
    {
        cubeView.Init();
        dispatcher.AddListener(Demo1MediatroEvent.ScoreChange,OnScoreChange);

        cubeView.dispatcher.AddListener(Demo1MediatroEvent.ClickDown, OnClickDown);
        //通过dispatcher发起请求分数的命令
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo1MediatroEvent.ScoreChange,OnScoreChange);
        cubeView.dispatcher.RemoveListener(Demo1MediatroEvent.ClickDown, OnClickDown);
    }

    public void OnScoreChange(IEvent evt)
    {
        cubeView.UpdateScore((int)evt.data);
    }

    public void OnClickDown()
    {
        dispatcher.Dispatch(Demo1CommandEvent.UpdateScore);
    }
}
