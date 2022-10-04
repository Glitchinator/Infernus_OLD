using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class Scythe : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Scythe");
		}
		public override void SetDefaults()
		{
			Projectile.width = 44;
			Projectile.height = 52;
			Projectile.aiStyle = 24;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 300;
			Projectile.penetrate = 5;
			Projectile.extraUpdates = 1;
			Projectile.tileCollide = false;


		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			for (int k = 0; k < 20; k++)
			{
                float hitDirection = 0;
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.2f);
			}
			if (Main.rand.Next(2) < 1)
			{
				if (Main.rand.Next(2) < 1)
				{
					int a = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 8f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.FairyQueenMagicItemShot, (int)(Projectile.damage * .70f), 0, Projectile.owner);
					Main.projectile[a].tileCollide = false;
					Main.projectile[a].friendly = true;
				}
			}
		}
	}
}