using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] AnimatorOverrideController _animator2;
    BossBehavior _owner;

    int _ownerListIndex;

    bool _bossSpawned;

    public BossBehavior Owner { get => _owner; set => _owner = value; }
    public int OwnerListIndex { get => _ownerListIndex; set => _ownerListIndex = value; }
    public bool BossSpawned { get => _bossSpawned; set => _bossSpawned = value; }

    private void Start()
    {
        switch(Random.Range(0, 2))
        {
            case 1:
                _animator.runtimeAnimatorController = _animator2;
                break;
        }
    }
}

