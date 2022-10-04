using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class honey : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Grenade");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
			AIType = ProjectileID.ThrowingKnife;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.Bullet;
			return true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			{
				for (int i = 0; i < 2; i++)
				{
					int a = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.StyngerShrapnel, (int)(Projectile.damage * .25f), 0, Projectile.owner);
					Main.projectile[a].aiStyle = 1;
					Main.projectile[a].tileCollide = true;
				}
			}
			Projectile.Kill();
		}
	}
}