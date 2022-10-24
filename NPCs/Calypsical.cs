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
        }

		public override void SetDefaults()
		{
			NPC.lifeMax = 1033000;
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
            Music = MusicID.OtherworldlyWoF;
            NPC.noTileCollide = true;
			NPC.lavaImmune = true;
            NPC.npcSlots = 8;
        }

        const float ShootKnockback = 0.8554f;

        int Timer;

        public override void AI()
        {
            Player player = Main.player[NPC.target];

            damage = NPC.lifeMax - NPC.life;
            NPC.defense = (int)(damage * .000444f);

            {
                Move(new Vector2((Main.rand.Next(0)), -400f));
                Timer++;
                if (Timer >= 50)
                {
                    Target();
                }
                else if (Timer == 60)
                {

                    Dash();
                    spread360shot();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 110)
                {
                    Dash();
                    spread360shot();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                else if (Timer == 160)
                {
                    Dash();
                    spread360shot();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 210)
                {
                    Dash();
                    spread360shot();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 260)
                {
                    Dash();
                    spread360shot();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 280)
                {
                    homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    spreadslowfast();
                }
                if (Timer == 300)
                {
                    homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    spreadslowfast();
                }
                if (Timer == 320)
                {
                    homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    spreadslowfast();
                }
                if (Timer == 340)
                {
                    homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    spreadslowfast();
                }
                else if (Timer == 400)
                {

                    Dash();
                    spread360shot();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 450)
                {

                    Dash();
                    spread360shot();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                else if (Timer == 500)
                {
                    Dash();
                    spread360shot();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 550)
                {
                    Dash();
                    spread360shot();
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
                    spread360shot();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 780)
                {
                    Dash();
                    spread360shot();
                    SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, NPC.position);
                }
                if (Timer == 830)
                {
                    Dash();
                    spread360shot();
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
                    rapidfire();
                    speed = 100;
                    Move(new Vector2((Main.rand.Next(0)), -400f));
                }
                if (Timer == 1020)
                {
                    homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    spreadslowfast();
                }
                if (Timer == 1040)
                {
                    homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    spreadslowfast();
                }
                if (Timer == 1060)
                {
                    homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    spreadslowfast();
                }
                if (Timer == 1080)
                {
                    homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    spreadslowfast();
                }
                if (Timer == 1100)
                {
                    homingmissles();
                    SoundEngine.PlaySound(SoundID.Item94, NPC.position);
                    spreadslowfast();
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
                    NPC.dontTakeDamage = true;
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

                        if (Main.netMode == 0)
                        {
                            Main.NewText("You Cannot slay me, not without dying FIRST", 145, 9, 18);
                        }
                        if (Main.netMode == 1)
                        {
                            Main.NewText("You Cannot slay me, not without dying FIRST", 145, 9, 18);
                        }
                        if (Main.netMode == 2)
                        {
                            Main.NewText("You Cannot slay me, not without dying FIRST", 145, 9, 18);
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
                } 

                if (Timer >= 1450)
                {
                    NPC.dontTakeDamage = false;
                }
            }
            base.AI();
            NPC.TargetClosest(true);

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
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.damage = (int)(NPC.damage * .6f);
            NPC.lifeMax = (int)(NPC.lifeMax = 1503600 + numPlayers);
        }
        private void Dash()
        {
            NPC.velocity.X *= 13f;
            NPC.velocity.Y *= 13f;
            Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
            {
                float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), (vector8.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                NPC.velocity.X = (float)(Math.Cos(rotation) * 18) * -1;
                NPC.velocity.Y = (float)(Math.Sin(rotation) * 18) * -1;
            }
            //Dust
            NPC.ai[0] %= (float)Math.PI * 2f;
            Vector2 offset = new Vector2((float)Math.Cos(NPC.ai[0]), (float)Math.Sin(NPC.ai[0]));
            NPC.ai[2] = -80;
            Color color = new Color();
            Rectangle rectangle = new Rectangle((int)NPC.position.X, (int)(NPC.position.Y + ((NPC.height - NPC.width) / 2)), NPC.width, NPC.width);
            int count = 45;
            for (int i = 1; i <= count; i++)
            {
                int dust = Dust.NewDust(NPC.position, rectangle.Width, rectangle.Height, 31, 0, 0, 100, color, 2.5f);
                Main.dust[dust].noGravity = false;
            }
            return;
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
            for (int i = 0; i < 6; i++)
            {
                int type = ProjectileID.RayGunnerLaser;
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

                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.Center, newVelocity, type, 45, .5f);
            }
        }
        private void homingmissles()
        {
            for (int i = 0; i < 3; i++)
            {
                int type = ProjectileID.FlamingScythe;
                Vector2 velocity = NPC.Center - NPC.Center;
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
                newVelocity *= 1f - Main.rand.NextFloat(.1f);

                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.Center, newVelocity, type, 60, .5f);
            }
        }
        private void rapidfire()
        {

            int type = ProjectileID.EyeBeam;
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
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.Center, velocity, type, 60, .5f);
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
        private void Target()
        {
            player = Main.player[NPC.target];
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
            float turnResistance = 45f;
            move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            NPC.velocity = move;
        }
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
        private void spreadslowfast()
        {
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, -7, 0, ModContent.ProjectileType<Projectiles.HomingBoss>(), 40, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 7, 0, ModContent.ProjectileType<Projectiles.HomingBoss>(), 40, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 0, 7, ModContent.ProjectileType<Projectiles.HomingBoss>(), 40, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 0, -7, ModContent.ProjectileType<Projectiles.HomingBoss>(), 40, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, -7, -7, ModContent.ProjectileType<Projectiles.HomingBoss>(), 40, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 7, -7, ModContent.ProjectileType<Projectiles.HomingBoss>(), 40, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, -7, 7, ModContent.ProjectileType<Projectiles.HomingBoss>(), 40, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.position.X + 40, NPC.position.Y + 40, 7, 7, ModContent.ProjectileType<Projectiles.HomingBoss>(), 40, ShootKnockback, Main.myPlayer, 0f, 0f);
        }
        private void spread360shot()
        {
            for (int i = 0; i < 16; i++)
            {
                int type = ProjectileID.RayGunnerLaser;
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

                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), NPC.Center, newVelocity, type, 46, .5f);
            }
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
                        Main.NewText("You Cannot Escape", 145, 9, 18);
                    }
                    if (Main.netMode == 1)
                    {
                        Main.NewText("You Cannot Escape", 145, 9, 18);
                    }
                    if (Main.netMode == 2)
                    {
                        Main.NewText("You Cannot Escape", 145, 9, 18);
                    }
                    for (int k = 0; k < 1; k++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 4f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
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