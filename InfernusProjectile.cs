using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Infernus
{
    public class InfernusProjectiles : GlobalProjectile
    {
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (DownedBoss.Level_systemON == true && projectile.hostile == true)
            {
                projectile.damage = (int)(projectile.damage * 1.4f);
            }
        }
    }
}
