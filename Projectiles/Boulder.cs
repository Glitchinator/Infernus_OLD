using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class Boulder : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boulder");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
			AIType = ProjectileID.BoulderStaffOfEarth;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.BoulderStaffOfEarth;
			return true;
		}
	}
}