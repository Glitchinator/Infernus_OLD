using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Tools
{
	public class Pickaxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Aeritite Pickaxe");
			Tooltip.SetDefault("Can mine meteorite");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 6, 60, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.crit = 4;
			Item.autoReuse = true;
			Item.pick = 55;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Materials.Gravel>(), 9);
			recipe.AddTile(ModContent.TileType<Work>());
			recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Materials.Gaming>(), 12);
			recipe.Register();
		}
	}
}
