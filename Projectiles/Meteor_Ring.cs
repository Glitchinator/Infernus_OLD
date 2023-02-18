using Infernus.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{

    public class Meteor_Ring : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 112;
            Projectile.height = 52;
            Projectile.friendly = true;
            Projectile.minion = false;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 18000;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<Meteor_Buff>());
            }
            if (player.HasBuff(ModContent.BuffType<Meteor_Buff>()))
            {
                Projectile.timeLeft = 2;
            }

            Projectile.Center = player.Center;
            Projectile.position.X = player.position.X - 6;
            Projectile.position.Y = player.position.Y - 10;
            Projectile.rotation = player.velocity.X * -0.01f;
        }
    }
}