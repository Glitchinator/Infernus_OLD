using Infernus.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.NPCs
{
	public class Boulderminiboss : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive Sleeper");
			Main.npcFrameCount[NPC.type] = 1;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 6000;
			NPC.damage = 20;
			NPC.defense = 19;
			NPC.knockBackResist = 0.0f;
			NPC.width = 100;
			NPC.height = 80;
			NPC.aiStyle = 43;
			NPC.noGravity = false;
			NPC.noTileCollide = false;
			NPC.HitSound = SoundID.NPCHit7;
			NPC.DeathSound = SoundID.NPCDeath41;
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
					Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Stone, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.2f);
				}
				{
					for (int k = 0; k < damage / NPC.lifeMax * 50.0; k++)
					{
						Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Stone, (float)hitDirection, -1f, 0, default(Color), 1.2f);
					}
				}
			}
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Rock>(), 4, 1, 2));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Melee.bould>(), 55, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.Whiprock>(), 55, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Magic.Venom>(), 55, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Ranged.Bog>(), 55, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Accessories.Wings>(), 55, 1, 1));
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				new FlavorTextBestiaryInfoElement("A boulder mad that you killed Raiko, crashes into walls at high speeds and staggers themselves, silly boulders")
			});
		}
	}
}