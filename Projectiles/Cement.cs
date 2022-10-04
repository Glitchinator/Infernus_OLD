using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class Cement : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rough Ball");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.BallofFire);
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}
	}
}