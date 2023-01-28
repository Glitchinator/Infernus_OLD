using Infernus.Placeable;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.NPCs
{
    [AutoloadBossHead]
    public class Boulderminiboss : ModNPC
    {
        private Player player;
        private float speed;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Base Rocker");
            Main.npcFrameCount[NPC.type] = 2;
            NPCID.Sets.MPAllowedEnemies[Type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCDebuffImmunityData debuffData = new()
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.Poisoned,
                    BuffID.Venom,

                    BuffID.Confused
                }
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 29600;
            NPC.damage = 80;
            NPC.defense = 38;
            NPC.knockBackResist = 0.0f;
            NPC.width = 250;
            NPC.height = 126;
            NPC.aiStyle = -1;
            NPC.noGravity = false;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath41;
            AnimationType = NPCID.DemonEye;
            NPC.value = Item.buyPrice(0, 0, 70, 0);
            NPC.boss = true;
            Music = MusicID.PirateInvasion;
        }
        int Timer;
        public override void AI()
        {
            NPC.netUpdate = true;
            Move(new Vector2((Main.rand.Next(0)), 0f));
            {
                Timer++;
                if (Timer == 60)
                {
                    Dash();
                }
                if (Timer == 110)
                {
                    Dash();
                }
                if (Timer == 160)
                {
                    bigshot();
                }
                if (Timer == 230)
                {
                    Dash();
                }
                if (Timer == 260)
                {
                    Shoot();
                }
                if (Timer == 290)
                {
                    Shoot();
                }
                if (Timer == 350)
                {
                    bigshot();
                }
                if (Timer == 400)
                {
                    Shoot2();
                }
                if (Timer == 430)
                {
                    Dash();
                }
                if (Timer == 480)
                {
                    Shoot2();
                }
                if (Timer == 520)
                {
                    Shoot2();
                }
                if (Timer == 580)
                {
                    Timer = 0;
                }
            }
            base.AI();
            NPC.TargetClosest(true);
            Player player = Main.player[NPC.target];
            Vector2 target = NPC.HasPlayerTarget ? player.Center : Main.npc[NPC.target].Center;

            NPC.rotation = 0.0f;
            NPC.netAlways = true;
            NPC.TargetClosest(true);

            if (NPC.life >= NPC.lifeMax)
                NPC.life = NPC.lifeMax;

            if (NPC.target < 0 || NPC.target == 255 || player.dead || !player.active)
            {
                NPC.TargetClosest(false);
                NPC.direction = 1;
                NPC.velocity.Y = NPC.velocity.Y + 1f;
                if (NPC.timeLeft > 20)
                {
                    NPC.timeLeft = 20;
                    return;
                }
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.damage = (int)(NPC.damage * 1f);
            NPC.lifeMax = (int)(NPC.lifeMax = 37800 + numPlayers);
        }
        private void Dash()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.velocity.X *= 3f;
                NPC.velocity.Y *= 3f;
                Vector2 whereboss = new(NPC.position.X + (NPC.width), NPC.position.Y + (NPC.height));
                {
                    float rotation = (float)Math.Atan2((whereboss.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height)), (whereboss.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width)));
                    NPC.velocity.X = (float)(Math.Cos(rotation) * 18) * -1;
                    NPC.velocity.Y = (float)(Math.Sin(rotation) * 18) * -1;
                }
            }
        }

        private void Move(Vector2 offset)
        {
            player = Main.player[NPC.target];
            speed = 10f;
            if (Main.expertMode == true)
            {
                speed = 12f;
            }
            Vector2 moveTo = player.Center + offset;
            Vector2 move = moveTo - NPC.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 28f;
            move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            NPC.velocity = move;
        }
        private void bigshot()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                var entitySource = NPC.GetSource_FromAI();
                for (int i = 0; i < 6; i++)
                {
                    Vector2 velocity = player.Center - NPC.Center;
                    float magnitude = Magnitude(velocity);
                    if (magnitude > 0)
                    {
                        velocity *= 6f / magnitude;
                    }
                    else
                    {
                        velocity = new Vector2(0f, 5f);
                    }
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(180));

                    Projectile.NewProjectile(entitySource, NPC.Center, newVelocity, ProjectileID.PoisonSeedPlantera, 25, NPC.whoAmI);
                }
            }
        }
        private void Shoot()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                var entitySource = NPC.GetSource_FromAI();
                for (int i = 0; i < 5; i++)
                {
                    Vector2 velocity = player.Center - NPC.Center;
                    float magnitude = Magnitude(velocity);
                    if (magnitude > 0)
                    {
                        velocity *= 11f / magnitude;
                    }
                    else
                    {
                        velocity = new Vector2(0f, 5f);
                    }
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(35));
                    newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                    Projectile.NewProjectile(entitySource, NPC.Center, newVelocity, ProjectileID.PoisonDartTrap, 25, NPC.whoAmI);
                }
            }
        }
        private void Shoot2()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                var entitySource = NPC.GetSource_FromAI();
                Vector2 velocity = player.Center - NPC.Center;
                float magnitude = Magnitude(velocity);
                if (magnitude > 0)
                {
                    velocity *= 16f / magnitude;
                }
                else
                {
                    velocity = new Vector2(0f, 5f);
                }

                Projectile.NewProjectile(entitySource, NPC.Center, velocity, ProjectileID.QueenBeeStinger, 25, NPC.whoAmI);
            }
        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Stone, 2.5f * hitDirection, -2.5f, 0, default, 1.2f);
                }
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.LifeFruit, 75, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.StoneBlock, 1, 4, 6));
            npcLoot.Add(ItemDropRule.Common(ItemID.BoulderStatue, 95, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Rock>(), 4, 2, 3));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Melee.bould>(), 12, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.Whiprock>(), 12, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Magic.Venom>(), 12, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Magic.Bouldermagicweapon>(), 12, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Ranged.Bog>(), 12, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Accessories.Wings>(), 12, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Accessories.HiveHeart>(), 12, 1, 1));
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
                new FlavorTextBestiaryInfoElement("A mass of rock, vines and beehives enchanted by a jungle green rune. Dug out from the ground after being attacked.")
            });
        }
        public override void OnKill()
        {
            DownedBoss.downedBoulderInvasionHM = true;
        }
    }
}