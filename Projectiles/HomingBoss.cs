using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{
    public class HomingBoss : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy BLAST");
        }

        public sealed override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.HallowBossRainbowStreak);
            AIType = ProjectileID.HallowBossRainbowStreak;
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.tileCollide = false;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 2;
            Projectile.netImportant = true;
            Projectile.netUpdate = true;
            Projectile.rotation = Projectile.velocity.X * 0.02f;
        }
        public override bool? CanCutTiles()
        {
            return false;
        }
        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Clentaminator_Red, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }
        }
    }
}