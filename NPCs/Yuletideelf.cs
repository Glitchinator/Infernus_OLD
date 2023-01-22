﻿using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.NPCs
{
	public class Yuletideelf : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yuletide Elf");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 680;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.knockBackResist = 0.2f;
			NPC.width = 34;
			NPC.height = 46;
			NPC.aiStyle = 26;
			NPC.noGravity = false;
			AnimationType = NPCID.Zombie;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 2, 0, 0);
			NPC.lavaImmune = true;
			NPC.trapImmune = true;
			NPC.scale = .8f;
		}
		public override void AI()
		{
			if (Main.rand.NextBool(6))
			{
				Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, DustID.GreenTorch, NPC.velocity.X * 0.5f, NPC.velocity.Y * 0.5f);
				Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, DustID.RedTorch, NPC.velocity.X * 0.5f, NPC.velocity.Y * 0.5f);
				Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, DustID.WhiteTorch, NPC.velocity.X * 0.5f, NPC.velocity.Y * 0.5f);
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
				for (int k = 0; k < 16; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Confetti, 4f * hitDirection, -2.5f, 0, default, 1f);
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return .001f;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
				new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				new FlavorTextBestiaryInfoElement("It was moving? Take a deep breath nobody will believe you.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.ChristmasTree, 1, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.RedLight, 3, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.GreenLight, 3, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.BlueLight, 3, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.StarTopper2, 2, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.MulticoloredLights, 2, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.WhiteAndRedGarland, 2, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.ElfHat, 4, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.ElfShirt, 4, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.ElfPants, 4, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.Present, 1, 2, 4));
		}
	}
}