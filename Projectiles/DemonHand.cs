﻿using Infernus.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{

    public class DemonHand : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.width = 70;
            Projectile.height = 78;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.minionSlots = 1f;
            Projectile.penetrate = -1;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 7;
            target.immune[Projectile.owner] = 7;
        }
        public override void AI()
        {
            Projectile.rotation += (float)Projectile.direction * 14;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Player player = Main.player[Projectile.owner];

            Vector2 withplayer = player.Center;
            withplayer.Y -= 48f;
            float notamongusX = (10 + Projectile.minionPos * 40) * -player.direction;
            withplayer.X += notamongusX;
            Vector2 vectorToplayer = withplayer - Projectile.Center;
            float distanceToplayer = vectorToplayer.Length();
            if (Main.myPlayer == player.whoAmI && distanceToplayer > 2000f)
            {
                Projectile.position = withplayer;
                Projectile.velocity *= 0.1f;
            }

            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<DemonBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<DemonBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            float distanceFromTarget = 250f;
            Vector2 targetCenter = Projectile.position;
            bool foundTarget = false;

            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, Projectile.Center);
                if (between < 2000f)
                {
                    distanceFromTarget = between;
                    targetCenter = npc.Center;
                    foundTarget = true;
                }
            }
            if (!foundTarget)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, Projectile.Center);
                        bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
                        bool closeThroughWall = between < 100f;
                        if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }
            Projectile.friendly = foundTarget;


            float speed = 10f;
            float inertia = 15f;

            if (foundTarget)
            {
                if (distanceFromTarget > 40f)
                {
                    Vector2 direction = targetCenter - Projectile.Center;
                    direction.Normalize();
                    direction *= speed;
                    Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
                }
            }
            else
            {
                if (distanceToplayer > 600f)
                {
                    speed = 15f;
                    inertia = 35f;
                }
                else
                {
                    speed = 6f;
                    inertia = 50f;
                }
                if (distanceToplayer > 20f)
                {
                    vectorToplayer.Normalize();
                    vectorToplayer *= speed;
                    Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToplayer) / inertia;
                }
                else if (Projectile.velocity == Vector2.Zero)
                {
                    Projectile.velocity.X = -0.01f;
                    Projectile.velocity.Y = -0.01f;
                }
            }
        }
        public override bool MinionContactDamage()
        {
            return true;
        }
    }
}