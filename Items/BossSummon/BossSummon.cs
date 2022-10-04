using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.BossSummon
{
	public class BossSummon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Receivers Call");
			Tooltip.SetDefault("Summons Ruberibus");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 2;
		}

		public override void SetDefaults() 
		{
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 4;
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.Orange;
			Item.consumable = true;
			Item.maxStack = 20;
		}
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(Mod.Find<ModNPC>("Boss2").Type) && (player.ZoneSnow);
        }

        public override bool? UseItem(Player player)
		{
			SoundEngine.PlaySound(SoundID.ForceRoar, player.position);
			if (Main.netMode != 1)
            {
				NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("Boss2").Type);
			}
			return true;
		}
	}
}