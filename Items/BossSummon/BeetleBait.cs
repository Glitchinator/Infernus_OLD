using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.BossSummon
{
	public class BeetleBait : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Beetle Bait");
			Tooltip.SetDefault("Summons a Fish"
                + "\n Must be in ocean biome");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 2;
		}

		public override void SetDefaults() 
		{
			Item.width = 32;
			Item.height = 22;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 4;
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.consumable = true;
			Item.maxStack = 20;
		}
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(Mod.Find<ModNPC>("Shark").Type) && (player.ZoneBeach);
		}

        public override bool? UseItem(Player player)
		{
			SoundEngine.PlaySound(SoundID.ForceRoar, player.position);
			if(Main.netMode != 1)

            {
				NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("Shark").Type);
			}
			return true;
		}
		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BeetleHusk, 16);
			recipe.AddIngredient(ItemID.Grubby, 3);
			recipe.AddIngredient(ItemID.Buggy, 3);
			recipe.AddIngredient(ItemID.Sluggy, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}