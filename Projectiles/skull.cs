using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace Infernus.Projectiles
{
	
	public class skull : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skull Basher");
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.PaladinsHammerFriendly);
			AIType = ProjectileID.PaladinsHammerFriendly;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Melee;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.PaladinsHammerFriendly;
			return true;
		}
	}
}