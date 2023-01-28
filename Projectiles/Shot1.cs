using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
            Projectile.netImportant = true;
        }
    }
}