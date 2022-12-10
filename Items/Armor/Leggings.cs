using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class Leggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aeritite Leggings");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.buyPrice(0, 1, 25, 0);
			Item.rare = ItemRarityID.Green;
			Item.defense = 5;
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Gravel>(), 8);
			recipe.AddIngredient(ModContent.ItemType<Materials.Gaming>(), 16);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}