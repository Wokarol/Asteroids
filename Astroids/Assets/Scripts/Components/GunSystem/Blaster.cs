using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wokarol.PoolSystem;

namespace Wokarol.WeaponSystem
{
    public class Blaster : SingleShootGun
    {
        [SerializeField] Pool bulletPool;

        protected override void Shoot()
        {
            var obj = bulletPool.Get(transform.position, transform.rotation);
        }
    }
}
