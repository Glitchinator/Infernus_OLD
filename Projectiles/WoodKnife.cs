using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class WoodKnife : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wood Dagger");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.BoneDagger);
			AIType = ProjectileID.BoneDagger;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}
	}
}