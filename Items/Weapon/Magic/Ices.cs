using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Magic
{
	public class Ices : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Ice");
			Tooltip.SetDefault("Shoots 3 ice bolts");
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Magic;
			Item.width = 54;
			Item.height = 54;
			Item.useAnimation = 12;
			Item.useTime = 4;
			Item.reuseDelay = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.buyPrice(0, 10, 50, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ProjectileID.IceBolt;
			Item.shootSpeed = 9f;
			Item.mana = 12;
			Item.crit = 4;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.IceSpikes>(), 26);
			recipe.AddIngredient(ItemID.IceBlock, 30);
			recipe.AddIngredient(ItemID.Obsidian, 25);
			recipe.AddTile(ModContent.TileType<Tiles.Work>());
			recipe.Register();
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
		}
    }
}