using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1Context : MVCSContext
{
    public Demo1Context(MonoBehaviour view) : base(view) { }

    protected override void mapBindings()//进行绑定
    {
        //Manager
        injectionBinder.Bind<AudioManager>().To<AudioManager>().ToSingleton();

        //model
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();

        //service
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();//表示这个对象只会在整个工程中生成一个

        //command
        commandBinder.Bind(Demo1CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(Demo1CommandEvent.UpdateScore).To<UpdateScoreCommand>();

        //mediator
        mediationBinder.Bind<CubeView>().To<CubeMediator>();//完成view和mediator的绑定



        //绑定开始事件   一个StartCommand
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
