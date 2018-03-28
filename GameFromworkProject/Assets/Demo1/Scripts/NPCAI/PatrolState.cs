using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    private int targetWayPoint = 0;
    private Transform[] wayPoints;
    private GameObject npc;
    private GameObject player;
    private Rigidbody npcRd;

    public PatrolState(Transform[] wp,GameObject npc,GameObject player)
    {
        stateID = StateID.Patrol;
        this.npc = npc;
        this.player = player;
        wayPoints = wp;
        npcRd = npc.GetComponent<Rigidbody>();
    }

    public override void DoBeforeEntering()
    {
        Debug.Log("Entering state "+ID);
    }

    public override void DoUpdate()
    {
        CheckTransition();
        PatrolMove();
    }

    //检查转换条件
    private void CheckTransition()
    {
        if (Vector3.Distance(player.transform.position, npc.transform.position) < 5)
        {
            fsm.PerformTransition(Transition.SawPlayer);
        }
    }

    private void PatrolMove()
    {
        npcRd.velocity = npc.transform.forward * 3f;
        Transform targetTran = wayPoints[targetWayPoint];
        Vector3 targetPosition = targetTran.position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);
        if (Vector3.Distance(npc.transform.position, targetPosition) < 1)
        {
            targetWayPoint++;
            targetWayPoint %= wayPoints.Length;
        };
    }
}
