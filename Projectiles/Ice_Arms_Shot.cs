using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Infernus.Buffs;

namespace Infernus.Projectiles
{

    public class Ice_Arms_Shot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Circle");
        }
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Generic;
            Projectile.aiStyle = 24;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.netImportant = true;
            Projectile.penetrate = 1;
        }
        public override void AI()
        {
            float maxDetectRadius = 400f;
            float projSpeed = 9f;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
                return;

            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
            Projectile.rotation = Projectile.velocity.ToRotation();

            Projectile.velocity.Y += Projectile.ai[0];
        }
        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;

            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                if (target.CanBeChasedBy())
                {
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }
    }
}