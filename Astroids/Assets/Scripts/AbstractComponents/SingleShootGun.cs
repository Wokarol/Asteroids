using UnityEngine;

namespace Wokarol.WeaponSystem
{
    public abstract class SingleShootGun : Gun
    {
        bool shooted = false;
        private void Update()
        {
            if(input.Shoot && !shooted) {
                shooted = true;
                // On key down
                Shoot();
            } else if (!input.Shoot && shooted) {
                shooted = false;
                // On key up
            }
        }

        protected abstract void Shoot();
    }
}