using Infernus.Placeable;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.NPCs
{
    public class Boulder3jung : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive Catalyst");
			Main.npcFrameCount[NPC.type] = 1;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 1000;
			NPC.damage = 0;
			NPC.defense = 22;
			NPC.knockBackResist = 0.0f;
			NPC.width = 90;
			NPC.height = 60;
			NPC.aiStyle = -1;
			NPC.noGravity = false;
			NPC.noTileCollide = false;
			NPC.HitSound = SoundID.NPCHit7;
			NPC.DeathSound = SoundID.NPCDeath41;
            Banner = Item.NPCtoBanner(NPCID.RockGolem);
            BannerItem = Item.BannerToItem(Banner);
            NPC.value = Item.buyPrice(0, 0, 0, 20);
        }
        public override void AI()
        {;

            NPC.TargetClosest(true);
            Player player = Main.player[NPC.target];
            Vector2 target = NPC.HasPlayerTarget ? player.Center : Main.npc[NPC.target].Center;


            spawnnpc();
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
					Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Stone, 2.5f * hitDirection, -2.5f, 0, default, 1.2f);
				}
			}
		}
        private void spawnnpc()
        {
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient && (InfernusWorld.BoulderInvasionUp == true) &&!NPC.AnyNPCs(Mod.Find<ModNPC>("Boulderminiboss").Type))
            {
                var entitySource = NPC.GetSource_FromAI();
                NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Boulderminiboss>(), NPC.whoAmI);
				NPC.life = 0;
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
            npcLoot.Add(ItemDropRule.Common(ItemID.LifeFruit, 75, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.StoneBlock, 1, 4, 6));
            npcLoot.Add(ItemDropRule.Common(ItemID.BoulderStatue, 95, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Rock>(), 4, 2, 3));
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
				new FlavorTextBestiaryInfoElement("A boulder mound with hives festering on it.")
			});
		}
        public override void OnKill()
        {
            DownedBoss.downedBoulderInvasionHM = true;
        }
    }
}