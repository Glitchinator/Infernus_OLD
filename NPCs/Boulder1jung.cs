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
	public class Boulder1jung : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bulbder");
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 4560;
			NPC.damage = 60;
			NPC.defense = 28;
			NPC.knockBackResist = 0.0f;
			NPC.width = 40;
			NPC.height = 40;
			NPC.aiStyle = 41;
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
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 1, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.2f);
				}
				{
					for (int k = 0; k < damage / NPC.lifeMax * 50.0; k++)
					{
						Dust.NewDust(NPC.position, NPC.width, NPC.height, 1, (float)hitDirection, -1f, 0, default(Color), 1.2f);
					}
				}
			}
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			// Do NOT misuse the ModifyNPCLoot and OnKill hooks: the former is only used for registering drops, the latter for everything else
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
				new FlavorTextBestiaryInfoElement("A boulder mad that you killed Raiko, long slept in the jungle, now awakens to crush you")
			});
		}
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.damage = (int)(NPC.damage * .6f);
            NPC.lifeMax = (int)(NPC.lifeMax * 1.3f);
        }
        public override void OnKill()
        {
            DownedBoss.downedBoulderInvasionHM = true;
        }
    }
}