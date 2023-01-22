using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
            Projectile.netImportant = true;
            Projectile.penetrate = -1;
        }

        public override bool PreKill(int timeLeft)
        {
            Projectile.type = ProjectileID.Bananarang;
            return true;
        }
    }
}