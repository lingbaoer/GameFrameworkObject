﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPoolList:ScriptableObject
{//继承自ScriptableObject表示把类GameObjectPoolList变成可以自定义资源配置的文件
    public List<GameObjectPool> poolList;
}
