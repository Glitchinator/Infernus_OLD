using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Infernus.Projectiles
{
	
	public class Lazar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ZAP");
		}
		public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.Bullet);
            AIType = ProjectileID.Bullet;
            Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
            Projectile.height = 48;
            Projectile.width = 8;
			Projectile.hostile = false;
			Projectile.light = .8f;
		}
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}