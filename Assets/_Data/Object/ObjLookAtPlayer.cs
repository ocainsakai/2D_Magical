using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtPlayer : ObjLookAtTarget
{

    [Header("Look At Player")]
    [SerializeField] protected GameObject player;

    protected override void FixedUpdate()
    {
        this.GetPlayerPosition();
        base.FixedUpdate();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player");
        Debug.LogWarning(transform.name + ": LoadPlayer", gameObject);
    }

    protected virtual void GetPlayerPosition()
    {
        if (this.player == null) return;

        this.targetPosition = this.player.transform.position;
        this.targetPosition.z = 0;
    }

}
