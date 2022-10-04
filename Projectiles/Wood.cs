using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{

	public class Wood : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wood Javelin");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.JavelinFriendly);
			AIType = ProjectileID.JavelinFriendly;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}
	}
}