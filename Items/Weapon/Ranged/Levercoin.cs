using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Ranged
{
	public class Levercoin : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lever Action Rifle");
			Tooltip.SetDefault("Mark em");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 46;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 64;
			Item.height = 28;
			Item.useAnimation = 44;
			Item.useTime = 44;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(0, 9, 50, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item40;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ProjectileID.SilverCoin;
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 4;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectileDirect(source, position, velocity, ProjectileID.SilverCoin, damage, knockback, player.whoAmI);

            return false;
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 16);
            recipe.AddIngredient(ItemID.Bone, 12);
            recipe.AddIngredient(ItemID.Wood, 6);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
	}
}