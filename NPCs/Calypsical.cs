using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Infernus.Items.BossSummon;
using Terraria.DataStructures;

namespace Infernus.NPCs
{
    [AutoloadBossHead]
    public class Calypsical : ModNPC
    {
        private Player player;
        private float speed;
        private int damage;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calypsical");
			Main.npcFrameCount[NPC.type] = 3;

            NPCID.Sets.MPAllowedEnemies[Type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.Ichor,
                    BuffID.BetsysCurse,

                    BuffID.Confused
                }
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
        }

		public override void SetDefaults()
		{
			NPC.lifeMax = 533000;
			NPC.damage = 120;
			NPC.defense = 0;
			NPC.knockBackResist = 0.0f;
			NPC.width = 200;
			NPC.height = 276;
			NPC.aiStyle = -1;
			NPC.noGravity = true;
			NPC.HitSound = SoundID.Tink;
			NPC.DeathSound = SoundID.NPCDeath62;
			NPC.value = Item.buyPrice(1, 50, 0, 0);
			NPC.boss = true;
            AIType = NPCID.AngryBones;
            Music = MusicID.LunarBoss;
            NPC.noTileCollide = true;
			NPC.lavaImmune = true;
            NPC.npcSlots = 8;
        }

        int Timer;

        public override void AI()
        {
            NPC.netUpdate = true;
            damage = NPC.lifeMax - NPC.life;
            NPC.defense = (int)(damage * .000444f);
            NPC.despawnEncouraged = false;

            {
                Move(new Vector2((Main.rand.Next(0)), -400f));
                Timer++;
                if (Timer == 60)
                {

                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 110)
                {
                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 160)
                {
                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 210)
                {
                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 260)
                {
                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 280)
                {
                    Homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    HomingStars();
                }
                if (Timer == 300)
                {
                    Homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    HomingStars();
                }
                if (Timer == 320)
                {
                    Homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    HomingStars();
                }
                if (Timer == 340)
                {
                    Homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    HomingStars();
                }
                if (Timer == 400)
                {

                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 450)
                {

                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 500)
                {
                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 550)
                {
                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 580)
                {
                    Shotgunblast();
                    SoundEngine.PlaySound(SoundID.Item36, NPC.position);
                }
                if (Timer == 620)
                {
                    Shotgunblast();
                    SoundEngine.PlaySound(SoundID.Item36, NPC.position);
                }
                if (Timer == 690)
                {
                    SpawnMinions();
                    SoundEngine.PlaySound(SoundID.Item96, NPC.position);
                }
                if (Timer == 730)
                {
                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 780)
                {
                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 830)
                {
                    Dash();
                    Shotgun360();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 900)
                {
                    SpawnMinions();
                    SoundEngine.PlaySound(SoundID.Item96, NPC.position);
                }
                if (Timer == 930)
                {
                    Shotgunblast();
                    SoundEngine.PlaySound(SoundID.Item36, NPC.position);
                }
                if (Timer == 960)
                {
                    Shotgunblast();
                    SoundEngine.PlaySound(SoundID.Item36, NPC.position);
                    speed = 100;
                }
                if (Timer >= 1000)
                {
                    Rapidfire();
                    speed = 100;
                    Move(new Vector2((Main.rand.Next(0)), -400f));
                }
                if (Timer == 1020)
                {
                    Homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    HomingStars();
                }
                if (Timer == 1040)
                {
                    Homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    HomingStars();
                }
                if (Timer == 1060)
                {
                    Homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    HomingStars();
                }
                if (Timer == 1080)
                {
                    Homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    HomingStars();
                }
                if (Timer == 1100)
                {
                    Homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    HomingStars();
                }
                if (Timer == 1150)
                {
                    if(NPC.dontTakeDamage == false)
                    {
                        Timer = 0;
                    }
                }
                if (NPC.life <= 2000)
                {
                    Music = MusicID.Credits;

                    if (Main.rand.NextBool(10))
                    {
                        NPC.ai[0] %= (float)Math.PI * 2f;
                        Vector2 offset = new Vector2((float)Math.Cos(NPC.ai[0]), (float)Math.Sin(NPC.ai[0]));
                        NPC.ai[2] = -80;
                        Color color = new Color();
                        Rectangle rectangle = new Rectangle((int)NPC.position.X, (int)(NPC.position.Y + ((NPC.height - NPC.width) / 2)), NPC.width, NPC.width);
                        int count = 14;
                        for (int i = 1; i <= count; i++)
                        {
                            int dust = Dust.NewDust(NPC.position, rectangle.Width, rectangle.Height, DustID.Smoke, 0, 0, 100, color, 4f);
                            Main.dust[dust].noGravity = false;
                        }
                    }
                    if (Main.rand.NextBool(12))
                    {
                        NPC.ai[0] %= (float)Math.PI * 2f;
                        Vector2 offset = new Vector2((float)Math.Cos(NPC.ai[0]), (float)Math.Sin(NPC.ai[0]));
                        NPC.ai[2] = -80;
                        Color color = new Color();
                        Rectangle rectangle = new Rectangle((int)NPC.position.X, (int)(NPC.position.Y + ((NPC.height - NPC.width) / 2)), NPC.width, NPC.width);
                        int count = 17;
                        for (int i = 1; i <= count; i++)
                        {
                            int dust = Dust.NewDust(NPC.position, rectangle.Width, rectangle.Height, DustID.Torch, 0, 0, 100, color, 4f);
                            Main.dust[dust].noGravity = false;
                        }
                        SoundEngine.PlaySound(SoundID.NPCDeath14, NPC.position);
                    }
                    if (Timer == 1180)
                    {
                        if (Main.netMode == NetmodeID.SinglePlayer)
                        {
                            Main.NewText("I cannot believe what I am feeling.", 159, 0, 0);
                        }
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            Main.NewText("I cannot believe what I am feeling.", 159, 0, 0);
                        }
                    }
                    if (Timer == 1270)
                    {
                        if (Main.netMode == NetmodeID.SinglePlayer)
                        {
                            Main.NewText("Defeat, such a cause for distress, I won't let it happen.", 159, 0, 0);
                        }
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            Main.NewText("Defeat, such a cause for distress, I won't let it happen.", 159, 0, 0);
                        }
                    }
                    if (Timer == 1360)
                    {
                        if (Main.netMode == NetmodeID.SinglePlayer)
                        {
                            Main.NewText("I congratulate you on your triumph. But this will not do. Gods must favor the irony, I sought the best.", 159, 0, 0);
                        }
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            Main.NewText("I congratulate you on your triumph. But this will not do. Gods must favor the irony, I sought the best.", 159, 0, 0);
                        }
                    }
                    if (Timer >= 1360)
                    {
                        NPC.dontTakeDamage = false;
                        return;
                    }
                    else
                    {
                        NPC.dontTakeDamage = true;
                    }
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
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.damage = (int)(NPC.damage * .6f);
            NPC.lifeMax = (int)(NPC.lifeMax = 703600 + numPlayers);
        }
        private void Dash()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.velocity.X *= 17f;
                NPC.velocity.Y *= 17f;
                Vector2 whereboss = new Vector2(NPC.position.X + (NPC.width), NPC.position.Y + (NPC.height));
                {
                    float rotation = (float)Math.Atan2((whereboss.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height)), (whereboss.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width)));
                    NPC.velocity.X = (float)(Math.Cos(rotation) * 24) * -1;
                    NPC.velocity.Y = (float)(Math.Sin(rotation) * 24) * -1;
                }
            }
        }
        private void SpawnMinions()
        {

            int count = MinionCount();
            var entitySource = NPC.GetSource_FromAI();

            for (int i = 0; i < count; i++)
            {
                int index = NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CalypsicalMinion>(), NPC.whoAmI);
                NPC minionNPC = Main.npc[index];

                if (minionNPC.ModNPC is CalypsicalMinion minion)
                {
                    minion.ParentIndex = NPC.whoAmI;
                    minion.PositionIndex = i;
                }

                if (Main.netMode == NetmodeID.Server && index < Main.maxNPCs)
                {
                    NetMessage.SendData(MessageID.SyncNPC, number: index);
                }
            }
        }
        private void Shotgunblast()
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
                        velocity *= 9f / magnitude;
                    }
                    else
                    {
                        velocity = new Vector2(0f, 5f);
                    }
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(35));
                    newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                    Projectile.NewProjectile(entitySource, NPC.Center, newVelocity, ProjectileID.RayGunnerLaser, 45, NPC.whoAmI);
                }
            }
        }
        private void Homingmissles()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                var entitySource = NPC.GetSource_FromAI();
                for (int i = 0; i < 3; i++)
                {
                    Vector2 velocity = player.Center - NPC.Center;
                    float magnitude = Magnitude(velocity);
                    if (magnitude > 0)
                    {
                        velocity *= 20f / magnitude;
                    }
                    else
                    {
                        velocity = new Vector2(0f, 5f);
                    }
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(90));
                    newVelocity *= 1f - Main.rand.NextFloat(0.1f);

                    Projectile.NewProjectile(entitySource, NPC.Center, newVelocity, ProjectileID.FlamingScythe, 60, NPC.whoAmI);
                }
            }
        }
        private void Rapidfire()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                var entitySource = NPC.GetSource_FromAI();
                Vector2 velocity = player.Center - NPC.Center;
                float magnitude = Magnitude(velocity);
                if (magnitude > 0)
                {
                    velocity *= 9f / magnitude;
                }
                else
                {
                    velocity = new Vector2(0f, 5f);
                }

                Projectile.NewProjectile(entitySource, NPC.Center, velocity, ProjectileID.EyeBeam, 60, NPC.whoAmI);
            }
        }
        public static int MinionType()
        {
            return ModContent.NPCType<CalypsicalMinion>();
        }

        public static int MinionCount()
        {
            int count = 3;
            return count;
        }
        public override void FindFrame(int frameHeight)
        {
            int startFrame = 0;
            int finalFrame = 2;

            int frameSpeed = 5;
            NPC.frameCounter += 0.5f;
            NPC.frameCounter += NPC.velocity.Length() / 30f;
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
        private void Move(Vector2 offset)
        {
            player = Main.player[NPC.target];
            speed = 14f;
            Vector2 moveTo = player.Center + offset;
            Vector2 move = moveTo - NPC.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 40f;
            move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            NPC.velocity = move;
        }
        private static float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        private void HomingStars()
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
                        velocity *= 7f / magnitude;
                    }
                    else
                    {
                        velocity = new Vector2(0f, 5f);
                    }
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(180));

                    Projectile.NewProjectile(entitySource, NPC.Center, newVelocity, ModContent.ProjectileType<Projectiles.HomingBoss>(), 40, NPC.whoAmI);
                }
            }
        }
        private void Shotgun360()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                var entitySource = NPC.GetSource_FromAI();
                for (int i = 0; i < 16; i++)
                {
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
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(360));

                    Projectile.NewProjectile(entitySource, NPC.Center, newVelocity, ProjectileID.RayGunnerLaser, 46, NPC.whoAmI);
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if(NPC.life <= 0)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("A power you are. Judgement was my fist mistake. Your escape is futile though. For the machine is immortal", 159, 0, 0);
                }
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    Main.NewText("A power you are. Judgement was my fist mistake. Your escape is futile though. For the machine is immortal", 159, 0, 0);
                }
            }
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            if (NPC.life <= 0)
            {
                if (NPC.life <= 0)
                {
                    for (int k = 0; k < 1; k++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch, 4f * hitDirection, -2.5f, 0, default, 1f);
                    }
                    int backGoreType = Mod.Find<ModGore>("Scy1").Type;

                    int frontGoreType = Mod.Find<ModGore>("Scy2").Type;

                    var entitySource = NPC.GetSource_Death();

                    for (int i = 0; i < 1; i++)
                    {
                        Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    }

                    for (int i = 0; i < 1; i++)
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
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "The Angelic Mech " + name;
            potionType = ItemID.SuperHealingPotion;
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
				new FlavorTextBestiaryInfoElement("A galactic challenger that faces the worst of the universes threats, including you")
            });
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Mechbag>()));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Placeable.MechTrophy>(), 10));

            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Placeable.MechRelic>()));
            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Pets.MechItem>()));

            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Magic.Cyclone>(), 3));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Melee.HolyRam>(), 3));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Ranged.miniholy>(), 3));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.Mecharmr>(), 3));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.MechWhip>(), 3));

            npcLoot.Add(notExpertRule);
        }
        public override void OnKill()
        {
            DownedBoss.downedCalypsical = true;
        }

    }
}