using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Infernus.Projectiles
{
	
	public class Cement : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rough Ball");
		}
		public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.SpikyBallTrap);
            AIType = ProjectileID.SpikyBallTrap;
            Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.hostile = false;
            Projectile.penetrate = 4;
		}
    }
}