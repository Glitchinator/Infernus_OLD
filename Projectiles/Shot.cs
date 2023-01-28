using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
            Projectile.netUpdate = true;
        }
    }
}