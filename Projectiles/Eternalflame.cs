﻿using Infernus.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{
    public class Eternalflame : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = false;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public sealed override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.height = 60;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.minionSlots = 1f;
            Projectile.penetrate = -1;
        }
        public override bool? CanCutTiles()
        {
            return false;
        }
        public override bool MinionContactDamage()
        {
            return true;
        }
        protected float shootCool = 18f;

        public override void AI()
        {
            if (Main.rand.NextBool(2))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Shadowflame, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.PurpleTorch, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }

            Player player = Main.player[Projectile.owner];

            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<flameBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<flameBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            Projectile.Center = player.Center;
            Projectile.position.X = player.position.X - 10;
            Projectile.position.Y = player.position.Y - 23;
            Projectile.rotation = player.velocity.X * -0.01f;


            float distanceFromTarget = 250f;
            Vector2 targetCenter = Projectile.position;
            bool foundTarget = false;

            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                {
                    targetCenter = npc.Center;
                    foundTarget = true;
                    Projectile.ai[0] = 0f;
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
                            targetCenter = npc.Center;
                            foundTarget = true;
                            Projectile.ai[0] = 0f;
                        }
                    }
                }
            }
            if (Projectile.ai[1] > 0f)
            {
                Projectile.ai[1] += 1f;
                if (Main.rand.NextBool(3))
                {
                    Projectile.ai[1] += 1f;
                }
            }
            if (Projectile.ai[1] > shootCool)
            {
                Projectile.ai[1] = 0f;
                Projectile.netUpdate = true;
            }
            if (Projectile.ai[0] == 0f)
            {
                if (foundTarget)
                {
                    if (Projectile.ai[1] == 0f)
                    {
                        Projectile.ai[1] = 1f;
                        if (Main.myPlayer == Projectile.owner)
                        {
                            Vector2 shootVel = targetCenter - Projectile.Center;
                            if (shootVel == Vector2.Zero)
                            {
                                shootVel = new Vector2(0f, 1f);
                            }
                            shootVel.Normalize();
                            shootVel *= 16;
                            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X + 40, Projectile.Center.Y, shootVel.X, shootVel.Y, ModContent.ProjectileType<eternalfire>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y + 40, shootVel.X, shootVel.Y, ModContent.ProjectileType<eternalfire>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
                            Projectile.ai[1] = 1f;
                        }
                    }
                }
            }
        }
    }
}