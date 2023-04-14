using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using System;
using Infernus.Buffs;

namespace Infernus.Projectiles
{
    public class Ice_Arms : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Arms");
        }
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Generic;
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.netImportant = true;
            Projectile.penetrate = -1;
            Projectile.damage = 30;
        }

        int Timer;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<IcyBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<IcyBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            double deg = (double)Projectile.ai[1];
            double rad = deg * (Math.PI / 180);
            double dist = 64;

            Projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
            Projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;

            Projectile.ai[1] += 1f;

            Timer++;

            if(Timer == 25)
            {
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<Ice_Arms_Shot>(), 36, 1.5f, Projectile.owner);
                Timer = 0;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 playerArmPosition = Main.GetPlayerArmPosition(Projectile);

            Asset<Texture2D> chainTexture = ModContent.Request<Texture2D>("Infernus/NPCs/Ruderibus_Arm");

            Rectangle? chainSourceRectangle = null;
            float chainHeightAdjustment = 0f;

            Vector2 chainOrigin = chainSourceRectangle.HasValue ? (chainSourceRectangle.Value.Size() / 2f) : (chainTexture.Size() / 2f);
            Vector2 chainDrawPosition = Projectile.Center;
            Vector2 vectorFromProjectileToPlayerArms = playerArmPosition.MoveTowards(chainDrawPosition, 4f) - chainDrawPosition;
            Vector2 unitVectorFromProjectileToPlayerArms = vectorFromProjectileToPlayerArms.SafeNormalize(Vector2.Zero);
            float chainSegmentLength = (chainSourceRectangle.HasValue ? chainSourceRectangle.Value.Height : chainTexture.Height()) + chainHeightAdjustment;
            if (chainSegmentLength == 0)
            {
                chainSegmentLength = 10;
            }
            float chainRotation = unitVectorFromProjectileToPlayerArms.ToRotation() + MathHelper.PiOver2;
            int chainCount = 0;
            float chainLengthRemainingToDraw = vectorFromProjectileToPlayerArms.Length() + chainSegmentLength / 2f;

            while (chainLengthRemainingToDraw > 0f)
            {
                var chainTextureToDraw = chainTexture;
                Main.spriteBatch.Draw(chainTextureToDraw.Value, chainDrawPosition - Main.screenPosition, chainSourceRectangle, Color.White, chainRotation, chainOrigin, 1f, SpriteEffects.None, 0f);
                chainDrawPosition += unitVectorFromProjectileToPlayerArms * chainSegmentLength;
                chainCount++;
                chainLengthRemainingToDraw -= chainSegmentLength;
            }
            return true;
        }
    }
}