using Infernus.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Projectiles
{

    public class Icy : ModProjectile
    {
        protected float idleAccel = 100f;
        protected float spacingMult = 0f;
        protected float viewDist = 350f;
        protected float inertia = 40f;
        protected float shootSpeed;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = false;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 24;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.minion = false;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 18000;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            inertia = 20f;
            shootSpeed = 12f;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            float spacing = (float)Projectile.width * spacingMult;
            for (int k = 0; k < 1000; k++)
            {
                Projectile otherProj = Main.projectile[k];
                if (k != Projectile.whoAmI && otherProj.active && otherProj.owner == Projectile.owner && otherProj.type == Projectile.type && Math.Abs(Projectile.position.X - otherProj.position.X) + Math.Abs(Projectile.position.Y - otherProj.position.Y) < spacing)
                {
                    if (Projectile.position.X < Main.projectile[k].position.X)
                    {
                        Projectile.velocity.X -= idleAccel;
                    }
                    else
                    {
                        Projectile.velocity.X += idleAccel;
                    }
                    if (Projectile.position.Y < Main.projectile[k].position.Y)
                    {
                        Projectile.velocity.Y -= idleAccel;
                    }
                    else
                    {
                        Projectile.velocity.Y += idleAccel;
                    }
                }
            }
            Vector2 targetPos = Projectile.position;
            float targetDist = viewDist;
            bool target = false;
            Projectile.tileCollide = true;
            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                if (Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height))
                {
                    targetDist = Vector2.Distance(Projectile.Center, targetPos);
                    targetPos = npc.Center;
                    target = true;
                }
            }
            else
            {
                for (int k = 0; k < 200; k++)
                {
                    NPC npc = Main.npc[k];
                    if (npc.CanBeChasedBy(this, false))
                    {
                        float distance = Vector2.Distance(npc.Center, Projectile.Center);
                        if ((distance < targetDist || !target) && Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height))
                        {
                            targetDist = distance;
                            targetPos = npc.Center;
                            target = true;
                        }
                    }
                }
            }
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<IcyBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<IcyBuff>()))
            {
                Projectile.timeLeft = 2;
            }
            {
                if (!Collision.CanHitLine(Projectile.Center, 1, 1, player.Center, 1, 1))
                {
                    Projectile.ai[0] = 1f;
                }
                float speed = 100f;
                if (Projectile.ai[0] == 1f)
                {
                    speed = 100f;
                }
                Vector2 center = Projectile.Center;
                Vector2 direction = player.Center - center;
                Projectile.ai[1] = 3600f;
                Projectile.netUpdate = true;
                int num = 1;
                for (int k = 0; k < Projectile.whoAmI; k++)
                {
                    if (Main.projectile[k].active && Main.projectile[k].owner == Projectile.owner && Main.projectile[k].type == Projectile.type)
                    {
                        num++;
                    }
                }
                direction.X -= (float)((10 + num * 40) * player.direction);
                direction.Y -= 70f;
                float distanceTo = direction.Length();
                if (distanceTo > 200f && speed < 100f)
                {
                    speed = 100f;
                }
                if (distanceTo < 100f && Projectile.ai[0] == 1f && !Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
                {
                    Projectile.ai[0] = 0f;
                    Projectile.netUpdate = true;
                }
                if (distanceTo > 2000f)
                {
                    Projectile.Center = player.Center;
                }
                if (distanceTo > 48f)
                {
                    direction.Normalize();
                    direction *= speed;
                    float temp = inertia / 2f;
                    Projectile.velocity = (Projectile.velocity * temp + direction) / (temp + 1);
                }
                else
                {
                    Projectile.direction = Main.player[Projectile.owner].direction;
                    Projectile.velocity *= (float)Math.Pow(0.9, 40.0 / inertia);
                }
            }
            Projectile.rotation = Projectile.velocity.X * 0.05f;
            if (Projectile.velocity.X > 0f)
            {
                Projectile.spriteDirection = Projectile.direction = -1;
            }
            else if (Projectile.velocity.X < 0.05f)
            {
                Projectile.spriteDirection = Projectile.direction = 1;
            }
            if (Projectile.ai[1] > 0f)
            {
                Projectile.ai[1] += 1f;
                if (Main.rand.NextBool(3))
                {
                    Projectile.ai[1] += 1f;
                }
            }
            if (Projectile.ai[1] > 100)
            {
                Projectile.ai[1] = 0f;
                Projectile.netUpdate = true;
            }
            if (Projectile.ai[0] == 0f)
            {
                if (target)
                {
                    if ((targetPos - Projectile.Center).X > 0f)
                    {
                        Projectile.spriteDirection = Projectile.direction = -1;
                    }
                    else if ((targetPos - Projectile.Center).X < 0f)
                    {
                        Projectile.spriteDirection = Projectile.direction = 1;
                    }
                    if (Projectile.ai[1] == 0f)
                    {
                        Projectile.ai[1] = 1f;
                        if (Main.myPlayer == Projectile.owner)
                        {
                            Vector2 shootVel = targetPos - Projectile.Center;
                            if (shootVel == Vector2.Zero)
                            {
                                shootVel = new Vector2(0f, 1f);
                            }
                            shootVel.Normalize();
                            shootVel *= shootSpeed;
                            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), Projectile.Center.X, Projectile.Center.Y, shootVel.X, shootVel.Y, ProjectileID.PurpleLaser, 1, Projectile.knockBack, Main.myPlayer, 0f, 0f);
                            Projectile.netUpdate = true;
                        }
                    }
                }
            }
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            fallThrough = true;
            return false;
        }
    }
}