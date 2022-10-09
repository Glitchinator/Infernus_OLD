using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class Frisbe : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skull Basher");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bananarang);
			AIType = ProjectileID.Bananarang;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Melee;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.Bananarang;
			return true;
		}
	}
}