using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{

	public class Slicer : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nuclear Slice");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.DeathSickle);
			AIType = ProjectileID.DeathSickle;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}
		public override void AI()
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Grass, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Grass, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
			}
		}
	}
}