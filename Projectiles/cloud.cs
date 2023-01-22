using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
            Projectile.CloneDefaults(ProjectileID.Bone);
            AIType = ProjectileID.Bone;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.netImportant = true;
        }
    }
}