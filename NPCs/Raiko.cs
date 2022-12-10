using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Infernus.Items.Weapon.Melee;
using Infernus.Items.BossSummon;

namespace Infernus.NPCs
{
    [AutoloadBossHead]
    public class Raiko : ModNPC
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
                    BuffID.Oiled,
                    BuffID.Daybreak,

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
            Music = MusicID.Boss2;
            NPC.noTileCollide = true;
			NPC.lavaImmune = true;
            NPC.npcSlots = 3;
        }

        int Timer;
        public override void AI()
        {
            NPC.netUpdate = true;
            {
                Timer++;
                if (Main.expertMode == true)
                {
                    if (Timer <= 140)
                    {
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
                    Move(new Vector2((Main.rand.Next(0)), -150f));
                }
                if (Timer == 146)
                {
                    SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                    Dash();
                }
                else if (Timer == 150)
                {
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
                NPC.velocity.Y = NPC.velocity.Y - 1f;
                if (NPC.timeLeft > 20)
                {
                    NPC.timeLeft = 20;
                    return;
                }
            }
        }
        private void Move(Vector2 offset)
        {
            player = Main.player[NPC.target];
            speed = 35f;
            Vector2 moveTo = player.Center + offset;
            Vector2 move = moveTo - NPC.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 54f;
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
                for (int i = 0; i < 8; i++)
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
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(150));

                    Projectile.NewProjectile(entitySource, NPC.Center, newVelocity, ProjectileID.DeerclopsRangedProjectile, 12, NPC.whoAmI);
                }
            }
        }
        private void Dash()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.velocity.X *= 3f;
                NPC.velocity.Y *= 3f;
                Vector2 whereboss = new Vector2(NPC.position.X + (NPC.width), NPC.position.Y + (NPC.height));
                {
                    float rotation = (float)Math.Atan2((whereboss.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height)), (whereboss.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width)));
                    NPC.velocity.X = (float)(Math.Cos(rotation) * 18) * -1;
                    NPC.velocity.Y = (float)(Math.Sin(rotation) * 18) * -1;
                }
            }
        }
        public override void OnKill()
        {
            DownedBoss.downedRaiko = true;
        }

        private void spawnnpc()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                var entitySource = NPC.GetSource_FromAI();
                NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Midlite>(), NPC.whoAmI);
            }
        }
        private void Shoot()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                var entitySource = NPC.GetSource_FromAI();
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
                Projectile.NewProjectile(entitySource, NPC.Center, velocity, ModContent.ProjectileType<Projectiles.Shot>(), 12, NPC.whoAmI);
            }
        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("Meteors storm the upper atmosphere. Burning before they touch ground, such a sight to see.", 239, 106, 15);
                }
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    Main.NewText("Meteors storm the upper atmosphere. Burning before they touch ground, such a sight to see.", 239, 106, 15);
                }
            }

            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            if (NPC.life <= 0)
            {
                for (int k = 0; k < 1; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch, 4f * hitDirection, -2.5f, 0, default, 1f);
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
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.damage = (int)(NPC.damage * .6f);
            NPC.lifeMax = (int)(NPC.lifeMax = 3260 + numPlayers);
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
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
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Boss1bag>()));
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