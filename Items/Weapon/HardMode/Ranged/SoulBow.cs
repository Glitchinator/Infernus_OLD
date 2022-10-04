using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Ranged
{
	public class SoulBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Breaker Bow");
			Tooltip.SetDefault("Converts arrows to powerful javelins");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 44;
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.width = 26;
			Item.height = 40;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 14, 50, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 15f;
			Item.crit = 6;
			Item.useAmmo = AmmoID.Arrow;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 offset = new Vector2(velocity.X * 3, velocity.Y * 3);
			position += offset;
			type = ProjectileID.DD2BallistraProj;
			Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(1));
			Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), position, velocity, type, damage, knockback, player.whoAmI);
			return false;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.Weapon.Ranged.Firebow>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Items.Weapon.Ranged.IceBow>(), 1);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(ItemID.SoulofLight, 4);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
