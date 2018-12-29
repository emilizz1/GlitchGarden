using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : Health
{
    [SerializeField] float damageGivenBack;

    public override float DealDamage(float damage)
    {
        base.DealDamage(damage);
        return damageGivenBack;
    }
}
