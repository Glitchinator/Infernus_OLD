using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class Shot : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiny Meteor");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.CultistBossFireBall);
			AIType = ProjectileID.CultistBossFireBall;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.netImportant = true;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.CultistBossFireBall;
			return true;
		}
	}
}