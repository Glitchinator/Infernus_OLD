using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Infernus.Projectiles
{
	
	public class SwordTerra : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword Slash");
		}
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Melee;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.width = 40;
			Projectile.height = 80;
			Projectile.penetrate = 1;
		}
		public override void AI()
		{
            Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();
            Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);

            if (Main.rand.NextBool(2))
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Stone, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.GreenMoss, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }  
        }
    }
}