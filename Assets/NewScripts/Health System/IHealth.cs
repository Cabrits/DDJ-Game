using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth<T>
{
    void TakeDamage(T damageTaken);

    void Kill();

    void HealDamage(T damageHealed);
}
