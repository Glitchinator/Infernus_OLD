using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Infernus.Projectiles
{
	
	public class SwordProjecilte : ModProjectile
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
            Projectile.scale = 1.2f;
            Projectile.penetrate = 3;
		}
		public override void AI()
		{
            Projectile.spriteDirection = Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();
            Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);

            if (Main.rand.NextBool(2))
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Ambient_DarkBrown, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.OrangeTorch, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }  
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int a = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 8f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.DaybreakExplosion, (int)(Projectile.damage * 1.20f), 0, Projectile.owner);
            Main.projectile[a].tileCollide = false;
            Main.projectile[a].friendly = true;
            Main.projectile[a].DamageType = DamageClass.Melee;
        }
    }
}