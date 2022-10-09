using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class BoulderMini : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("mini Boulder");
		}
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Magic;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.width = 20;
			Projectile.height = 20;
		}
		public override void AI()
		{
			if (Main.rand.NextBool(2))
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Stone, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
			}

            Projectile.velocity.Y = Projectile.velocity.Y + 0.1f;
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 0;
            target.immune[Projectile.owner] = 0;
        }
    }
}