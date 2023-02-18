using Infernus.Items.BossSummon;
using Infernus.Items.Weapon.Melee;
using Infernus.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.NPCs
{
    [AutoloadBossHead]
    public class TemporalSquid : ModNPC
	{
        private Player player;
        private float speed;
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Temporal Glow Squid");
			Main.npcFrameCount[NPC.type] = 6;

            NPCID.Sets.MPAllowedEnemies[Type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCDebuffImmunityData debuffData = new()
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.Confused
                }
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
        }

		public override void SetDefaults()
		{
            NPC.lifeMax = 2450;
            NPC.damage = 14;
            NPC.defense = 13;
            NPC.knockBackResist = 0.0f;
            NPC.width = 54;
            NPC.height = 180;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.HitSound = SoundID.NPCHit8;
            NPC.DeathSound = SoundID.Roar;
            NPC.value = Item.buyPrice(0, 1, 50, 0);
            NPC.boss = true;
            AIType = NPCID.AngryBones;
            Music = MusicID.Boss1;
            NPC.noTileCollide = true;
            NPC.lavaImmune = true;
            NPC.npcSlots = 6;
        }
        int Timer;
        int frameSpeed = 16;
        bool secondphase = false;

        public override void AI()
        {
            Player player = Main.player[NPC.target];
            NPC.netUpdate = true;
            NPC.TargetClosest(true);
            NPC.rotation = NPC.velocity.X * 0.01f;

            if (NPC.target < 0 || NPC.target == 255 || player.dead || !player.active)
            {
                NPC.TargetClosest(false);
                NPC.velocity.Y = NPC.velocity.Y + .3f;
                if (NPC.timeLeft > 20)
                {
                    NPC.timeLeft = 20;
                    return;
                }
            }
            if(Main.expertMode == true || player.ZoneBeach == false)
            {
                Move(new Vector2((Main.rand.Next(0)), 0f));
            }
            else
            {
                Move(new Vector2((Main.rand.Next(0)), -230f));
            }
            if (NPC.life <= (NPC.lifeMax / 2))
            {
                secondphase = true;
            }
            Timer++;
            if(DownedBoss.Level_systemON == true)
            {
                if (secondphase == true)
                {
                    if (Timer == 1060)
                    {
                        SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                        InkBolt();
                    }
                    if (Timer == 1100)
                    {
                        SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                        Typhoon();
                        SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                        InkBolt();
                    }
                    if (Timer == 1180)
                    {
                        SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                        InkRain();
                    }
                    if (Timer == 1210)
                    {
                        SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                        Typhoon();
                        SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                        InkBolt();
                    }
                    if (Timer == 1270)
                    {
                        SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                        InkBolt();
                    }
                    if (Timer == 1330)
                    {
                        SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                        InkBolt();
                    }
                    if (Timer == 1390)
                    {
                        SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                        Typhoon();
                        SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                        InkBolt();
                    }
                    if (Timer == 1440)
                    {
                        SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                        Typhoon();
                        SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                        InkBolt();
                    }
                    if (Timer == 1490)
                    {
                        SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                        InkRain();
                    }
                    if (Timer == 1550)
                    {
                        SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                        Typhoon();
                        SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                        InkBolt();
                    }
                    if (Timer == 1610)
                    {
                        SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                        InkBolt();
                    }
                    if (Timer == 1670)
                    {
                        SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                        InkRain();
                    }
                    if (Timer == 1730)
                    {
                        SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                        InkBolt();
                    }
                    if (Timer == 1770)
                    {
                        SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                        InkBolt();
                    }
                    if (Timer == 1830)
                    {
                        SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                        InkRain();
                    }
                    if (Timer == 1730)
                    {
                        Timer = 1060;
                    }
                    SoundEngine.PlaySound(SoundID.Zombie93, NPC.position);
                    frameSpeed = 4;
                    return;
                }
                if (Timer == 60)
                {
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 120)
                {
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 180)
                {
                    SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                    Typhoon();
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 240)
                {
                    SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                    InkRain();
                }
                if (Timer == 300)
                {
                    SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                    InkRain();
                }
                if (Timer == 360)
                {
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 420)
                {
                    SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                    Typhoon();
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 480)
                {
                    SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                    Typhoon();
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 540)
                {
                    SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                    InkRain();
                }
                if (Timer == 600)
                {
                    SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                    InkRain();
                }
                if (Timer == 660)
                {
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 720)
                {
                    SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                    InkRain();
                }
                if(Timer == 780)
                {
                    SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                    Typhoon();
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 840)
                {
                    SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                    Typhoon();
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 780)
                {
                    Timer = 0;
                }
                return;
            }
            if(secondphase == true)
            {
                if (Timer == 1060)
                {
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 1100)
                {
                    SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                    Typhoon();
                }
                if (Timer == 1180)
                {
                    SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                    InkRain();
                }
                if (Timer == 1210)
                {
                    SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                    Typhoon();
                }
                if (Timer == 1270)
                {
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 1330)
                {
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 1390)
                {
                    SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                    Typhoon();
                }
                if (Timer == 1440)
                {
                    SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                    Typhoon();
                }
                if (Timer == 1490)
                {
                    SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                    InkRain();
                }
                if (Timer == 1550)
                {
                    SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                    Typhoon();
                }
                if (Timer == 1610)
                {
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 1670)
                {
                    SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                    InkRain();
                }
                if (Timer == 1730)
                {
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 1770)
                {
                    SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                    InkBolt();
                }
                if (Timer == 1830)
                {
                    SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                    InkRain();
                }
                if (Timer == 1730)
                {
                    Timer = 1060;
                }
                SoundEngine.PlaySound(SoundID.Zombie93, NPC.position);
                frameSpeed = 4;
                return;
            }
            if(Timer == 60)
            {
                SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                InkBolt();
            }
            if(Timer == 120)
            {
                SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                InkBolt();
            }
            if (Timer == 180)
            {
                SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                Typhoon();
            }
            if (Timer == 240)
            {
                SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                InkRain();
            }
            if (Timer == 300)
            {
                SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                InkRain();
            }
            if (Timer == 360)
            {
                SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                InkBolt();
            }
            if (Timer == 420)
            {
                SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                Typhoon();
            }
            if (Timer == 480)
            {
                SoundEngine.PlaySound(SoundID.Zombie103, NPC.position);
                Typhoon();
            }
            if (Timer == 540)
            {
                SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                InkRain();
            }
            if (Timer == 600)
            {
                SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                InkRain();
            }
            if (Timer == 660)
            {
                SoundEngine.PlaySound(SoundID.Item171, NPC.position);
                InkBolt();
            }
            if (Timer == 720)
            {
                SoundEngine.PlaySound(SoundID.NPCDeath19, NPC.position);
                InkRain();
            }
            if (Timer == 780)
            {
                Timer = 0;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            int startFrame = 0;
            int finalFrame = 2;

            if (secondphase == true)
            {
                startFrame = 3;
                finalFrame = 5;
            }
            else
            {
                startFrame = 0;
                finalFrame = 2;
            }
            NPC.frameCounter += 0.8f;
            NPC.frameCounter += NPC.velocity.Length() / 7f;
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
            speed = 6f;
            if (player.ZoneBeach == false)
            {
                speed = 9f;
            }
            Vector2 moveTo = player.Center + offset;

            Vector2 move = moveTo - NPC.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 32f;
            move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            NPC.velocity = move;
        }
        private void InkRain()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                for (int i = 0; i < 8; i++)
                {
                    player = Main.player[NPC.target];
                    Vector2 velocity = player.Center - NPC.Bottom;
                    float magnitude = Magnitude(velocity);
                    if (magnitude > 0)
                    {
                        velocity *= 8f / magnitude;
                    }
                    else
                    {
                        velocity = new Vector2(0f, 6f);
                    }
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(35));

                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Top, newVelocity, ModContent.ProjectileType<InkBomb>(), 15, NPC.whoAmI);
                }
            }
        }
        private void Typhoon()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {

                float spawnarea = player.velocity.X * 50;
                Vector2 position = player.Top + new Vector2(spawnarea + Main.rand.Next(-100, 100), Main.rand.Next(50, 100));

                Projectile.NewProjectile(NPC.GetSource_FromAI(), position, -Vector2.UnitY, ModContent.ProjectileType<InkTyphoon>(), 15, 0f, Main.myPlayer);
            }
        }
        private void InkBolt()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                player = Main.player[NPC.target];
                Vector2 velocity = player.Center - NPC.Bottom;
                float magnitude = Magnitude(velocity);
                if (magnitude > 0)
                {
                    velocity *= 22f / magnitude;
                }
                else
                {
                    velocity = new Vector2(0f, 7f);
                }
                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Bottom, velocity, ModContent.ProjectileType<InkBolt>(), 15, NPC.whoAmI);
            }
        }
        private static float Magnitude(Vector2 mag)
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
                for (int k = 0; k < 36; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, 4f * hitDirection, -2.5f, 0, default, 1f);
                }
                for (int i = 0; i < 1; i++)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), Mod.Find<ModGore>("Squid_Eye").Type);
                }
                for (int i = 0; i < 1; i++)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), Mod.Find<ModGore>("Squid_Head").Type);
                }
                for (int i = 0; i < 1; i++)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), Mod.Find<ModGore>("Squid_Tenticles").Type);
                }
            }
		}
		public override void OnKill()
		{
			DownedBoss.downedSquid = true;
		}
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
				new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				new FlavorTextBestiaryInfoElement("Don't get too indulged by it's fasinating looks, these squids might be small but pack a punch.")
			});
		}
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Squid_Bag>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Consumable.Potion>(), 1, 5, 8));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Placeable.Squid_Trophy>(), 10));

            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Placeable.Squid_Relic>()));
            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Pets.Squid_PetItem>()));

            LeadingConditionRule notExpertRule = new(new Conditions.NotExpert());

            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.Magic.Radiant_Staff>(), 3));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Ink_Sprinkler>(), 3));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.Ranged.Squid_Gun>(), 3));

            npcLoot.Add(notExpertRule);
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			NPC.damage = (int)(NPC.damage * 1.4f);
			NPC.lifeMax = 3350;
		}
        public override void OnSpawn(IEntitySource source)
        {
            if (Main.masterMode == true)
            {
                NPC.lifeMax = 4400;
                NPC.life = 4400;
                NPC.damage = ((NPC.damage / 2) * 3);
            }
            if (Main.getGoodWorld == true)
            {
                NPC.scale = .6f;
                NPC.lifeMax = 5650;
                NPC.life = 5650;
                NPC.damage = ((NPC.damage / 10) * 13);
            }
        }
    }
}