using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Infernus.Invas;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Infernus
{
    public class InfernusWorld : ModSystem
    {
        public static bool dungeonInvasionUp = false;
        public static bool downedDungeonInvasion = false;

        public override void OnWorldLoad()
        {
            Main.invasionSize = 0;
            dungeonInvasionUp = false;
            downedDungeonInvasion = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();
            if (downedDungeonInvasion) downed.Add("dungeonInvasion");

            new TagCompound {
                {"downed", downed}
            };
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedDungeonInvasion = downed.Contains("dungeonInvasion");
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedDungeonInvasion;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedDungeonInvasion = flags[0];
        }

        public override void PostUpdateWorld()
        {
            if (dungeonInvasionUp)
            {
                if (Main.invasionX == Main.spawnTileX)
                {
                    DungeonInvasion.CheckDungeonInvasionProgress();
                }
                DungeonInvasion.UpdateDungeonInvasion();
            }
        }
		public override void PostSetupContent()
		{
			DoBossChecklistIntegration();
		}
		private void DoBossChecklistIntegration()
		{

			if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod))
			{
				return;
			}
			if (bossChecklistMod.Version < new Version(1, 3, 1))
			{
				return;
			}
			string bossName = "Raiko";

			int bossType = ModContent.NPCType<NPCs.Boss>();

			float weight = 2.4f;

			Func<bool> downed = () => DownedBoss.downedRaiko;

			Func<bool> available = () => true;

			List<int> collection = new List<int>()
			{
				ModContent.ItemType<Placeable.RaikoRelic>(),
				ModContent.ItemType<Items.Pets.RaikoPetItem>(),
				ModContent.ItemType<Placeable.Trophy>(),
                ModContent.ItemType<Items.Weapon.Meteor>(),
                ModContent.ItemType<Items.Weapon.Ranged.Firebow>(),
                ModContent.ItemType<Items.Weapon.Magic.MeteorEater>(),
                ModContent.ItemType<Items.Weapon.Melee.BoldnBash>(),
                ModContent.ItemType<Items.Weapon.Summon.Minion>(),
				ModContent.ItemType<Items.Tools.Day>()
			};

			int summonItem = ModContent.ItemType<Items.BossSummon.Boss1sum>();

			string spawnInfo = $"Use a [i:{summonItem}]";

			string despawnInfo = null;

			var customBossPortrait = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Infernus/BossChecklist/Raiko").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};

			bossChecklistMod.Call(
				"AddBoss",
				Mod,
				bossName,
				bossType,
				weight,
				downed,
				available,
				collection,
				summonItem,
				spawnInfo,
				despawnInfo,
				customBossPortrait
			);


			string bossName1 = "Ruderibus";

			int bossType1 = ModContent.NPCType<NPCs.Boss2>();

			float weight1 = 5.8f;

			Func<bool> downed1 = () => DownedBoss.downedRuderibus;

			Func<bool> available1 = () => true;

			List<int> collection1 = new List<int>()
			{
				ModContent.ItemType<Placeable.RudeRelic>(),
				ModContent.ItemType<Items.Pets.RudeItem>(),
				ModContent.ItemType<Placeable.RudeTrophy>(),
				ModContent.ItemType<Items.Materials.IceSpikes>(),
				ItemID.FlurryBoots,
				ItemID.IceMirror,
				ItemID.IceBoomerang,
				ItemID.IceBlade,
				ItemID.BlizzardinaBottle,
				ItemID.SnowballCannon,
				ItemID.IceSkates,
				ItemID.IceMachine,
				ItemID.Fish,
			};

			int summonItem1 = ModContent.ItemType<Items.BossSummon.BossSummon>();

			string spawnInfo1 = $"Use a [i:{summonItem1}]";

			string despawnInfo1 = null;

			var customBossPortrait1 = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Infernus/BossChecklist/Ruderibus").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};

			bossChecklistMod.Call(
				"AddBoss",
				Mod,
				bossName1,
				bossType1,
				weight1,
				downed1,
				available1,
				collection1,
				summonItem1,
				spawnInfo1,
				despawnInfo1,
				customBossPortrait1
			);



			string bossName2 = "Flash-Frost Tiger Shark";

			int bossType2 = ModContent.NPCType<NPCs.Shark>();

			float weight2 = 16.9f;

			Func<bool> downed2 = () => DownedBoss.downedTigerShark;

			Func<bool> available2 = () => true;

			List<int> collection2 = new List<int>()
			{
				ModContent.ItemType<Placeable.SharkRelic>(),
				ModContent.ItemType<Placeable.SharkTrophy>(),
				ModContent.ItemType<Items.Weapon.HardMode.Accessories.eleScale>(),
				ModContent.ItemType<Items.Weapon.HardMode.Melee.Electricice>(),
				ModContent.ItemType<Items.Weapon.HardMode.Ranged.ElectricBow>(),
				ModContent.ItemType<Items.Weapon.HardMode.Magic.Lightning>(),
				ModContent.ItemType<Items.Weapon.HardMode.Summon.whiplight>(),
				ItemID.JellyfishDivingGear,
				ItemID.WaterWalkingBoots,
				ItemID.SharkFin,
				ItemID.FloatingTube
			};

			int summonItem2 = ModContent.ItemType<Items.BossSummon.BeetleBait>();

			string spawnInfo2 = $"Use a [i:{summonItem2}] or have it randomly spawn in the ocean biome";

			string despawnInfo2 = null;

			var customBossPortrait2 = (SpriteBatch sb, Rectangle rect, Color color) => {
				Texture2D texture = ModContent.Request<Texture2D>("Infernus/BossChecklist/TigerShark").Value;
				Vector2 centered = new Vector2(rect.X + (rect.Width / 2) - (texture.Width / 2), rect.Y + (rect.Height / 2) - (texture.Height / 2));
				sb.Draw(texture, centered, color);
			};

			bossChecklistMod.Call(
				"AddBoss",
				Mod,
				bossName2,
				bossType2,
				weight2,
				downed2,
				available2,
				collection2,
				summonItem2,
				spawnInfo2,
				despawnInfo2,
				customBossPortrait2
			);

			string minibossName = "Temporal Glow Squid";

			int minibossType = ModContent.NPCType<NPCs.tempsquid>();

			float miniweight = 0.9f;

			Func<bool> minidowned = () => DownedBoss.downedSquid;

			Func<bool> miniavailable = () => true;

			List<int> minicollection = new List<int>()
			{
				ModContent.ItemType<Items.Consumable.Potion>(),
				ItemID.BlackInk,
				ItemID.PinkJellyfish
			};

			int minisummonItem = ItemID.WoodenChair;

			string minispawnInfo = "Randomly spawns in ocean biome";

			string minidespawnInfo = null;

			bossChecklistMod.Call(
				"AddMiniBoss",
				Mod,
				minibossName,
				minibossType,
				miniweight,
				minidowned,
				miniavailable,
				minicollection,
				minisummonItem,
				minispawnInfo,
				minidespawnInfo
			);
        }
	}
}

