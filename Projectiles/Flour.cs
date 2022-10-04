using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace Infernus.Projectiles
{
	
	public class Flour : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloom Bomb");
		}
		public override void SetDefaults()
		{
			Projectile.width = 92;
			Projectile.height = 102;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.timeLeft = 300;
			Projectile.extraUpdates = 1;
			Projectile.tileCollide = false;
			Projectile.aiStyle = 18;


		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			{
				SoundEngine.PlaySound(SoundID.DD2_KoboldExplosion, Projectile.position);
				int a = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 8f, Main.rand.Next(0, 0) * .25f, Main.rand.Next(0, 0) * .25f, ProjectileID.DD2ExplosiveTrapT3Explosion, (int)(Projectile.damage * 1f), 0, Projectile.owner);
				Main.projectile[a].tileCollide = false;
				Main.projectile[a].friendly = true;
				int b = Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y - 8f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.RainbowCrystalExplosion, (int)(Projectile.damage * .80f), 0, Projectile.owner);
				Main.projectile[b].tileCollide = false;
				Main.projectile[b].friendly = true;
			}
		}
	}
}