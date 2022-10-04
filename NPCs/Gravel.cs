using Infernus.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Infernus.NPCs
{
	public class Gravel : ModNPC
	{
		public Gravel()
		{
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drone");
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 25;
			NPC.damage = 10;
			NPC.defense = 1;
			NPC.knockBackResist = 0.9f;
			NPC.width = 40;
			NPC.height = 68;
			NPC.aiStyle = 22;
			NPC.noGravity = true;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = Item.buyPrice(0, 0, 5, 0);
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.netMode == NetmodeID.Server)
			{
				return;
			}

				if (NPC.life <= 0)
				{
					for (int k = 0; k < 1; k++)
					{
						Dust.NewDust(NPC.position, NPC.width, NPC.height, 1, 4f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
					}
				int frontGoreType = Mod.Find<ModGore>("Dron2").Type;
				int backGoreType = Mod.Find<ModGore>("Dron1").Type;

				var entitySource = NPC.GetSource_Death();

					for (int i = 0; i < 1; i++)
					{
						Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
					}
				for (int i = 0; i < 3; i++)
				{
					Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
				}
				}
			}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Materials.Gravel>(), 1, 4, 6));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accesories.Throwing>(), 40, 1, 1));
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Overworld.Chance * .3f;
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				new FlavorTextBestiaryInfoElement("These drones have been really annoying with their buzzing lately, I wish they would buzz-off.")
			});
		}
	}
}