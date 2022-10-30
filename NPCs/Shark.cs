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
	public class Shark : ModNPC
	{
		private Player player;
		private float speed;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Serphious");
			Main.npcFrameCount[NPC.type] = 2;

			NPCID.Sets.MPAllowedEnemies[Type] = true;

			NPCID.Sets.BossBestiaryPriority.Add(Type);

			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] {

                    BuffID.Electrified,
                    BuffID.Frostburn2,
                    BuffID.Frostburn,


                    BuffID.Confused
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 80650;
			NPC.damage = 65;
			NPC.defense = 38;
			NPC.knockBackResist = 0.0f;
			NPC.width = 108;
			NPC.height = 40;
			NPC.aiStyle = 16;
			NPC.noGravity = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.noTileCollide = true;
			AnimationType = NPCID.DemonEye;
			NPC.breath = 999;
			NPC.breathCounter = 999;
			NPC.value = Item.buyPrice(gold: 36);
			NPC.boss = true;
			Music = MusicID.OtherworldlyPlantera;
		}
        int Timer;
		public override void AI()
        {
			NPC.netUpdate = true;
			{
                Timer++;
				if (Timer == 20)
				{
					Dash();
				}
				if (Timer == 35)
				{
					Dash();
				}
				if (Timer == 50)
				{
					Dash();
				}
				if (Timer == 70)
				{
					Shoot();
				}
				if (Timer == 85)
				{
					Dash();
				}
				if (Timer == 100)
				{
					Dash();
				}
				if (Timer == 115)
				{
					Dash();
				}
				if (Timer == 135)
				{
					Shoot();
				}
				if (Timer == 150)
				{
					Dash();
				}
				if (Timer >= 170)
				{
					Move(new Vector2((Main.rand.Next(900)), 0f));
				}
				if (Timer == 190)
				{
					bigshot();
				}
				if (Timer == 220)
				{
					bigshot();
				}
				if (Timer == 240)
				{
					bigshot();
				}
				if (Timer == 260)
				{
					bigshot();
				}
				if (Timer == 280)
				{
					bigshot();
				}
				if (Timer == 300)
				{
					bigshot();
				}
				if (Timer == 320)
				{
					bigshot();
				}
				if (Timer == 340)
				{
					bigshot();
				}
				if (Timer == 360)
				{
					bigshot();
				}
				if (Timer == 380)
				{
					bigshot();
				}
				if (Timer == 4000)
				{
					bigshot();
				}
				if (Timer == 420)
				{
					bigshot();
				}
				if (Timer >= 440)
				{
					Move(new Vector2((Main.rand.Next(0)), 700f));
				}
				if (Timer == 470)
				{
					spawnnpc();
				}
				if (Timer == 490)
				{
					spawnnpc();
				}
				if (Timer == 510)
				{
					spawnnpc();
				}
				if (Timer == 540)
				{
					Shoot();
				}
				if (Timer == 560)
				{
					Dash();
				}
				if (Timer == 580)
				{
					Move(new Vector2((Main.rand.Next(0)), 200f));
				}
				if (Timer == 600)
				{
					bigshot4();
				}
				if (Timer == 640)
				{
					Shoot2();
				}
				if (Timer == 680)
				{
					bigshot4();
				}
				if (Timer == 720)
				{
					Shoot2();
				}
				if (Timer == 760)
				{
					bigshot4();
				}
				if (Timer == 800)
				{
					Shoot2();
				}
				if (Timer == 840)
				{
					bigshot4();
				}
				if (Timer == 880)
				{
					Shoot2();
				}
				if (Timer == 920)
				{
					bigshot4();
				}
				if (Timer == 960)
				{
					Shoot2();
				}
				if (Timer == 1000)
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
			NPC.damage = (int)(NPC.damage * .4f);
			NPC.lifeMax = (int)(NPC.lifeMax = 110360 + numPlayers);
		}
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 1.5f;
			return null;
		}
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.GreaterHealingPotion;
		}
        private void bigshot()
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
                        velocity *= 7f / magnitude;
                    }
                    else
                    {
                        velocity = new Vector2(0f, 5f);
                    }
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(110));

                    Projectile.NewProjectile(entitySource, NPC.Center, newVelocity, ProjectileID.FairyQueenLance, 25, NPC.whoAmI);
                }
            }
        }
        private void bigshot4()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                var entitySource = NPC.GetSource_FromAI();
                for (int i = 0; i < 9; i++)
                {
                    Vector2 velocity = player.Center - NPC.Center;
                    float magnitude = Magnitude(velocity);
                    if (magnitude > 0)
                    {
                        velocity *= 6.5f / magnitude;
                    }
                    else
                    {
                        velocity = new Vector2(0f, 5f);
                    }
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(180));

                    Projectile.NewProjectile(entitySource, NPC.Center, newVelocity, ProjectileID.FrostWave, 25, NPC.whoAmI);
                }
            }
        }
		private void Move(Vector2 offset)
		{
			player = Main.player[NPC.target];
            speed = 75f;
			Vector2 moveTo = player.Center - offset;
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
        private void Shoot()
        {
            player = Main.player[NPC.target];
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

                Projectile.NewProjectile(entitySource, NPC.Center, velocity, ProjectileID.CultistBossLightningOrb, 15, NPC.whoAmI);
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
                    velocity *= 8f / magnitude;
                }
                else
                {
                    velocity = new Vector2(0f, 5f);
                }

                Projectile.NewProjectile(entitySource, NPC.Center, velocity, ProjectileID.CultistBossIceMist, 35, NPC.whoAmI);
            }
        }
		private void spawnnpc()
		{
			var entitySource = NPC.GetSource_FromAI();
			NPC.NewNPC(entitySource, (int)NPC.Center.X - 10, (int)NPC.Center.Y - 10, NPCID.DetonatingBubble, NPC.whoAmI);
			NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, NPCID.DetonatingBubble, NPC.whoAmI);
			NPC.NewNPC(entitySource, (int)NPC.Center.X + 10, (int)NPC.Center.Y + 10, NPCID.DetonatingBubble, NPC.whoAmI);
		}
		public override void OnKill()
		{
			DownedBoss.downedTigerShark = true;
		}
		private float Magnitude(Vector2 mag)
		{
			return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
		}
        private void Dash()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.velocity.X *= 12f;
                NPC.velocity.Y *= 12f;
                Vector2 whereboss = new Vector2(NPC.position.X + (NPC.width), NPC.position.Y + (NPC.height));
                {
                    float rotation = (float)Math.Atan2((whereboss.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height)), (whereboss.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width)));
                    NPC.velocity.X = (float)(Math.Cos(rotation) * 24) * -1;
                    NPC.velocity.Y = (float)(Math.Sin(rotation) * 24) * -1;
                }
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
				for (int k = 0; k < 45; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 229, 4f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
				}
				for (int k = 0; k < 45; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 228, 4f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
				}
			}
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
				new FlavorTextBestiaryInfoElement("Tiger Sharks are rare fish to see, but when you reel in the wrong one... well, a feral amalgamation dosen't like being pestered.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{

			npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.BossSummon.SharkBag>()));

			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Placeable.SharkTrophy>(), 10));

			npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Placeable.SharkRelic>()));
			npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Pets.RudeItem>()));

			LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Magic.Lightning>(), 3));
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Melee.Electricice>(), 3));
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.whiplight>(), 3));
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Ranged.ElectricBow>(), 3));

			npcLoot.Add(notExpertRule);
		}
	}
}