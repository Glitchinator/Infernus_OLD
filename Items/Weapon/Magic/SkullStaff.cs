using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Magic
{
	public class SkullStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skull Staff");
			Tooltip.SetDefault("Conjures bouncin bones");
            Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 38;
			Item.DamageType = DamageClass.Magic;
			Item.width = 48;
			Item.height = 48;
			Item.useAnimation = 38;
			Item.useTime = 38;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(0, 6, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Bone>();
			Item.shootSpeed = 13f;
			Item.mana = 8;
			Item.crit = 4;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 32);
            recipe.AddIngredient(ItemID.Silk, 8);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}