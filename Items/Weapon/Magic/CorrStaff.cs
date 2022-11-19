using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Magic
{
	public class CorrStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonite Staff");
			Tooltip.SetDefault("Shoot demonite energy shots to your left or right"
			+ "\n  goes faster how far your cursor is from the middle of the screen");
            Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 50;
			Item.useAnimation = 36;
			Item.useTime = 36;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4;
			Item.value = Item.buyPrice(0, 6, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.CorrShot>();
			Item.shootSpeed = 13f;
			Item.mana = 9;
			Item.crit = 4;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}