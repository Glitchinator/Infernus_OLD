using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Placeable
{
	public class Work : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Construction WorkBench");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = ModContent.TileType<Tiles.Work>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.WorkBench);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.Gravel>(), 8);
			recipe.Register();
		}
	}
}
