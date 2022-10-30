using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Melee
{
	public class Swingy : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Smoldered Sword");
			Tooltip.SetDefault("Goodbye space sword");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 7;
			Item.useAnimation = 25;
			Item.useStyle = 5;
			Item.knockBack = 1;
			Item.value = Item.buyPrice(0, 8, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swingy>();
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.shootSpeed = 40f;
			Item.crit = 6;
		}
		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Hot>(), 24);
			recipe.AddIngredient(ItemID.WoodenSword, 1);
			recipe.AddTile(ModContent.TileType<Work>());
			recipe.Register();
		}
	}
}