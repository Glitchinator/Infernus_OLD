using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Magic
{
	public class Flower : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sporive");
			Tooltip.SetDefault("Shoots a spore");
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Magic;
			Item.noMelee = true;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 5, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item8;
			Item.shoot = ProjectileID.TerrarianBeam;
			Item.shootSpeed = 13f;
			Item.crit = 6;
			Item.autoReuse = true;
			Item.mana = 8;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.JungleSpores, 16);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(ModContent.TileType<Tiles.Work>());
			recipe.Register();
		}
	}
}
