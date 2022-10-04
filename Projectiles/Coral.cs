using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class Coral : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coral Knife");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.BoneDagger);
			AIType = ProjectileID.BoneDagger;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.BoneDagger;
			return true;
		}
	}
}