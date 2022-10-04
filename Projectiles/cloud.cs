using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class cloud : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crasher Knife");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.JavelinFriendly);
			AIType = ProjectileID.JavelinFriendly;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.Bullet;
			return true;
		}
	}
}