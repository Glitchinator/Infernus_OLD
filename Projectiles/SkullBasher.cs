using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Infernus.Projectiles
{

    public class SkullBasher : ModProjectile
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
            Projectile.netImportant = true;
        }
    }
}