using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    BossBehavior _owner;

    int _ownerListIndex;

    public BossBehavior Owner { get => _owner; set => _owner = value; }
    public int OwnerListIndex { get => _ownerListIndex; set => _ownerListIndex = value; }
}
