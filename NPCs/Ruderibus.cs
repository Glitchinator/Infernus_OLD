using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using Terraria.DataStructures;

namespace Infernus.NPCs
{
    [AutoloadBossHead]
    public class Ruderibus : ModNPC
    {
        private Player player;
        private float speed;

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruderibus");
			Main.npcFrameCount[NPC.type] = 5;

            NPCID.Sets.MPAllowedEnemies[Type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.Frostburn,

                    BuffID.Confused
                }
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
        }

		public override void SetDefaults()
		{
			NPC.lifeMax = 7850;
			NPC.damage = 35;
			NPC.defense = 16;
			NPC.knockBackResist = 0.0f;
			NPC.width = 120;
			NPC.height = 120;
			NPC.aiStyle = -1;
			NPC.noGravity = true;
			NPC.HitSound = SoundID.NPCHit42;
			NPC.DeathSound = SoundID.NPCDeath44;
			NPC.value = Item.buyPrice(0, 10, 50, 0);
			NPC.boss = true;
            Music = MusicID.OtherworldlyUGHallow;
            NPC.noTileCollide = true;
			NPC.lavaImmune = true;
            NPC.npcSlots = 20;
        }

        const float ShootKnockback = 0.8554f;

        int Timer;
        public override void AI()
        {
            Target();
            Move(new Vector2((Main.rand.Next(0)), 0f));
            {
                Timer++;
                if (Main.expertMode == true)
                {
                    if (Timer == 0)
                    {
                        Shoot();
                    }
                    if (Timer == 60)
                    {
                        Shoot();
                    }
                    else if (Timer == 90)
                    {
                        Shoot2();
                    }
                    if (Timer == 120)
                    {
                        Shoot();
                    }
                    else if (Timer == 150)
                    {
                        bigshot();
                    }
                    if (Timer == 160)
                    {
                        bigshot2();
                    }
                    if (Timer == 190)
                    {
                        Shoot();
                    }
                    else if (Timer == 210)
                    {
                        bigshot();
                    }
                    if (Timer == 230)
                    {
                        Shoot();
                    }
                    else if (Timer == 260)
                    {
                        bigshot2();
                    }
                    if (Timer >= 266)
                    {
                        Timer = 0;
                    }
                }
                // if normal mode
                if (Timer == 0)
                {
                }
                if (Timer == 60)
                {
                    Shoot();
                }
                if (Timer == 120)
                {
                    Shoot();
                }
                else if (Timer == 150)
                {
                    bigshot();
                }
                if (Timer == 160)
                {
                    bigshot2();
                }
                if (Timer == 190)
                {
                    Shoot();
                }
                else if (Timer == 210)
                {
                    bigshot();
                }
                if (Timer == 230)
                {
                    Shoot();
                }
                else if (Timer == 260)
                {
                    bigshot2();
                }
                if (Timer >= 266)
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

        public override void OnKill()
        {
            DownedBoss.downedRuderibus = true;
        }

        private void Target()
        {
            player = Main.player[NPC.target];
        }

        private void Move(Vector2 offset)
        {
            speed = 6.5f;
            if (Main.expertMode == true)
            {
                speed = 7.9f;
            }
            Vector2 moveTo = player.Center + offset;
            Vector2 move = moveTo - NPC.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 30f;
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
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, -7, 0, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 7, 0, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 0, 7, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 0, -7, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, -7, -7, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 7, -7, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, -7, 7, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 7, 7, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
        }
        private void bigshot2()
        {
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 20, NPC.position.Y + 20, -5, 0, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 20, NPC.position.Y + 20, 5, 0, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 20, NPC.position.Y + 20, 0, 5, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 20, NPC.position.Y + 20, 0, -5, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 20, NPC.position.Y + 20, -5, -5, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 20, NPC.position.Y + 20, 5, -5, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 20, NPC.position.Y + 20, -5, 5, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 20, NPC.position.Y + 20, 5, 5, 257, 5, ShootKnockback, Main.myPlayer, 0f, 0f);
        }
        private void Shoot()
        {
            
            int type = ProjectileID.FrostWave;
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
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.Center, velocity, type, 15, .5f);
        }
        private void Shoot2()
        {

            int type = ProjectileID.CultistBossLightningOrb;
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
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.Center, velocity, type, 8, .4f);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            if (NPC.life <= 0)
            {
                if (Main.netMode == 0)
                {
                    Main.NewText("A storm is brewing", 175, 75, 255);
                }
                if (Main.netMode == 1)
                {
                    Main.NewText("A storm is brewing", 175, 75, 255);
                }
                for (int k = 0; k < 1; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 16, 4f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
                }
                int frontGoreType = Mod.Find<ModGore>("Ice2").Type;
                int backGoreType = Mod.Find<ModGore>("Ice1").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 5; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                }
                for (int i = 0; i < 1; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
                }
                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
            }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.damage = (int)(NPC.damage * .7f);
            NPC.lifeMax = (int)(NPC.lifeMax = 9750 + numPlayers);
        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "" + name;
            potionType = ItemID.HealingPotion;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.BossSummon.OctopusBag>()));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Placeable.RudeTrophy>(), 10));

            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Placeable.RudeRelic>()));
            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Pets.RudeItem>()));

            LeadingConditionRule notstatueRule = new LeadingConditionRule(new Conditions.NotFromStatue());

            int itemType = ModContent.ItemType<Items.Materials.IceSpikes>();
            var parameters = new DropOneByOne.Parameters()
            {
                ChanceNumerator = 1,
                ChanceDenominator = 1,
                MinimumStackPerChunkBase = 1,
                MaximumStackPerChunkBase = 1,
                MinimumItemDropsCount = 46,
                MaximumItemDropsCount = 46,
            };

            notstatueRule.OnSuccess(new DropOneByOne(itemType, parameters));

            npcLoot.Add(notstatueRule);
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
                new FlavorTextBestiaryInfoElement("The giant ice construct is the hive mind of a icy army, only dragged out by what it thought was a signal.")
            });
        }
        public override void FindFrame(int frameHeight)
        {
            int startFrame = 1;
            int finalFrame = 5;

            int frameSpeed = 5;
            NPC.frameCounter += 0.5f;
            NPC.frameCounter += NPC.velocity.Length() / 15f;
            if (NPC.frameCounter > frameSpeed)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;

                if (NPC.frame.Y > finalFrame * frameHeight)
                {
                    NPC.frame.Y = startFrame * frameHeight;
                }
            }
        }

    }
}