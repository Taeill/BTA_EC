using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    BossBehavior _owner;

    int _ownerListIndex;

    bool _bossSpawned;

    public BossBehavior Owner { get => _owner; set => _owner = value; }
    public int OwnerListIndex { get => _ownerListIndex; set => _ownerListIndex = value; }
    public bool BossSpawned { get => _bossSpawned; set => _bossSpawned = value; }
}
