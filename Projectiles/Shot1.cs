using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class Shot1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiny Meteor");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Boulder);
			AIType = ProjectileID.Boulder;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.Boulder;
			return true;
		}
	}
}