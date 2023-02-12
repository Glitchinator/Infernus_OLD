using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Infernus.Projectiles
{

    public class InkTyphoon : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ink Typhoon");

            Main.projFrames[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.aiStyle = 0;
            Projectile.width = 120;
            Projectile.height = 320;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.netImportant = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 940;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            Projectile.velocity.X = Projectile.velocity.X * .98f;
            Projectile.velocity.Y = Projectile.velocity.Y * .98f;

            if (Main.rand.NextBool(1))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Wraith, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Wraith, Projectile.velocity.X * -0.5f, Projectile.velocity.Y * -0.5f);

            Projectile.velocity *= 1f;
            if (++Projectile.frameCounter >= 14)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 3)
                {
                    Projectile.frame = 0;
                }
            }

            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 15;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Obstructed, 60, quiet: false);
        }
    }
}