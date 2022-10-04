﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Infernus.Projectiles;
using Terraria.ID;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Infernus.Items.Weapon.Melee;

namespace Infernus.NPCs
{
    [AutoloadBossHead]
    public class Boss : ModNPC
    {
        private Player player;
        private float speed;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Raiko");
			Main.npcFrameCount[NPC.type] = 2;

            NPCID.Sets.MPAllowedEnemies[Type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.OnFire,
                    BuffID.Frostburn,
                    BuffID.CursedInferno,
                    BuffID.ShadowFlame,

                    BuffID.Confused
				}
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
        }

		public override void SetDefaults()
		{
			NPC.lifeMax = 2850;
			NPC.damage = 28;
			NPC.defense = 12;
			NPC.knockBackResist = 0.0f;
			NPC.width = 120;
			NPC.height = 120;
			NPC.aiStyle = -1;
			NPC.noGravity = true;
			NPC.HitSound = SoundID.Item62;
			NPC.DeathSound = SoundID.NPCDeath10;
			NPC.value = Item.buyPrice(0, 8, 50, 0);
			NPC.boss = true;
            AnimationType = NPCID.DemonEye;
            AIType = NPCID.AngryBones;
            Music = MusicID.OtherworldlyUGCorrption;
            NPC.noTileCollide = true;
			NPC.lavaImmune = true;
            NPC.npcSlots = 3;
        }

        const float ShootKnockback = 0.8554f;

        int Timer;
        public override void AI()
        {
            {
                Timer++;
                if (Main.expertMode == true)
                {
                    if (Timer <= 140)
                    {
                        Target();
                        Move(new Vector2((Main.rand.Next(0)), -400f));
                    }
                    else if (Timer == 100)
                    {
                        Shoot();
                    }
                    if (Timer == 110)
                    {
                        SoundEngine.PlaySound(SoundID.NPCDeath43, NPC.position);
                        spawnnpc();
                    }
                    else if (Timer == 120)
                    {
                        SoundEngine.PlaySound(SoundID.Item60, NPC.position);
                        bigshot();
                    }
                    if (Timer == 140)
                    {
                        Target();
                        Move(new Vector2((Main.rand.Next(0)), -150f));
                    }
                    if (Timer == 146)
                    {
                        SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                        Dash();
                    }
                    if (Timer == 152)
                    {
                        Dash();
                    }
                    if (Timer == 158)
                    {
                        Dash();
                    }
                    else if (Timer == 160)
                    {
                        Target();
                        Move(new Vector2((Main.rand.Next(0)), -400f));
                    }
                    if (Timer == 170)
                    {
                        Shoot();
                    }
                    else if (Timer == 190)
                    {
                        Shoot();
                    }
                    if (Timer >= 200)
                    {
                        Timer = 0;
                    }
                }
                if (Timer <= 140)
                {
                    Target();
                    Move(new Vector2((Main.rand.Next(0)), -400f));
                }
                else if (Timer == 100)
                {
                    Shoot();
                }
                if (Timer == 110)
                {
                    SoundEngine.PlaySound(SoundID.NPCDeath43, NPC.position);
                    spawnnpc();
                }
                else if (Timer == 120)
                {
                    SoundEngine.PlaySound(SoundID.Item60, NPC.position);
                    bigshot();
                }
                if (Timer == 140)
                {
                    Target();
                    Move(new Vector2((Main.rand.Next(0)), -150f));
                }
                if (Timer == 146)
                {
                    SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                    Dash();
                }
                else if (Timer == 150)
                {
                    Target();
                    Move(new Vector2((Main.rand.Next(0)), -400f));
                }
                if (Timer == 160)
                {
                    Shoot();
                }
                else if (Timer == 180)
                {
                    Shoot();
                }
                if (Timer >= 190)
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
                NPC.velocity.Y = NPC.velocity.Y - 7f;
                if (NPC.timeLeft > 20)
                {
                    NPC.timeLeft = 20;
                    return;
                }
            }
        }
        private void Move(Vector2 offset)
        {
            speed = 35f; // Sets the max speed of the npc.
            Vector2 moveTo = player.Center + offset; // Gets the point that the npc will be moving to.
            Vector2 move = moveTo - NPC.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 54f; // The larget the number the slower the npc will turn.
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
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, -7, 0, 962, 9, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 7, 0, 962, 9, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 0, 7, 962, 9, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 0, -7, 962, 9, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, -7, -7, 962, 9, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 7, -7, 962, 9, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, -7, 7, 962, 9, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 7, 7, 962, 9, ShootKnockback, Main.myPlayer, 0f, 0f);
        }
        private void Dash()
        {
            NPC.velocity.X *= 0.98f;
            NPC.velocity.Y *= 0.98f;
            Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
            {
                float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), (vector8.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                NPC.velocity.X = (float)(Math.Cos(rotation) * 12) * -1;
                NPC.velocity.Y = (float)(Math.Sin(rotation) * 12) * -1;
            }
            //Dust
            NPC.ai[0] %= (float)Math.PI * 2f;
            Vector2 offset = new Vector2((float)Math.Cos(NPC.ai[0]), (float)Math.Sin(NPC.ai[0]));
            NPC.ai[2] = -80;
            Color color = new Color();
            Rectangle rectangle = new Rectangle((int)NPC.position.X, (int)(NPC.position.Y + ((NPC.height - NPC.width) / 2)), NPC.width, NPC.width);
            int count = 20;
            for (int i = 1; i <= count; i++)
            {
                int dust = Dust.NewDust(NPC.position, rectangle.Width, rectangle.Height, 6, 0, 0, 100, color, 2.5f);
                Main.dust[dust].noGravity = false;
            }
            return;
        }
        public override void OnKill()
        {
            DownedBoss.downedRaiko = true;
        }

        private void spawnnpc()
        {
            var entitySource = NPC.GetSource_FromAI();
            NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Midlite>(), NPC.whoAmI);
        }
        private void Target()
        {
            player = Main.player[NPC.target]; // This will get the player target.
        }
        private void Shoot()
        {

            int type = ModContent.ProjectileType<Projectiles.Shot>();
            Vector2 velocity = player.Center - NPC.Center;
            float magnitude = Magnitude(velocity);
            if (magnitude > 0)
            {
                velocity *= 8f / magnitude;
            }
            else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.Center, velocity, type, 12, .5f);
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
                if (NPC.life <= 0)
                {
                    if (Main.netMode == 0)
                    {
                        Main.NewText("The Meteors glare at you, The boulders want their fun", 175, 75, 255);
                    }
                    if (Main.netMode == 1)
                    {
                        Main.NewText("The Meteors glare at you, The boulders want their fun", 175, 75, 255);
                    }
                    for (int k = 0; k < 1; k++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 4f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
                    }
                    int backGoreType = Mod.Find<ModGore>("Raiko1").Type;

                    var entitySource = NPC.GetSource_Death();

                    for (int i = 0; i < 1; i++)
                    {
                        Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    }

                    SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
                }
            }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.damage = (int)(NPC.damage * .6f);
            NPC.lifeMax = (int)(NPC.lifeMax = 3260 + numPlayers);
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "" + name;
            potionType = ItemID.HealingPotion;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				new FlavorTextBestiaryInfoElement("Conceived from space itself, the vengeful spite meteor is here to get revenge for your actions")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.BossSummon.Boss1bag>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Tools.Day>()));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Placeable.Trophy>(), 10));

            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Placeable.RaikoRelic>()));
            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Pets.RaikoPetItem>()));

            LeadingConditionRule notstatueRule = new LeadingConditionRule(new Conditions.NotFromStatue());
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.Magic.MeteorEater>(), 3));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<BoldnBash>(), 3));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.Ranged.Firebow>(), 3));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.Summon.Minion>(), 3));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.Meteor>(), 3));

            int itemType = ModContent.ItemType<Items.Materials.Hot>();
            var parameters = new DropOneByOne.Parameters()
            {
                ChanceNumerator = 1,
                ChanceDenominator = 1,
                MinimumStackPerChunkBase = 1,
                MaximumStackPerChunkBase = 1,
                MinimumItemDropsCount = 52,
                MaximumItemDropsCount = 52,
            };

            notstatueRule.OnSuccess(new DropOneByOne(itemType, parameters));

            npcLoot.Add(notstatueRule);
            npcLoot.Add(notExpertRule);
        }

    }
}