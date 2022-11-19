using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Infernus.Projectiles
{
	
	public class CorrShot : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonite Energy");
		}
		public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.Bullet);
            AIType = ProjectileID.Bullet;
            Projectile.DamageType = DamageClass.Magic;
			Projectile.friendly = true;
            Projectile.height = 34;
            Projectile.width = 14;
			Projectile.hostile = false;
		}
        public override void AI()
        {
            if (Main.rand.NextBool(4))
            {
                Projectile.velocity.Y = -0.01f;
            }
            if (Main.rand.NextBool(4))
            {
                Projectile.velocity.Y = +0.01f;
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}