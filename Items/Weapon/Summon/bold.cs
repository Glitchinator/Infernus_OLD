using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Buffs;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Summon
{
    public class bold : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Staff");
			Tooltip.SetDefault("Summons a glided vortex to ram enemies");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 7;
			Item.width = 46;
			Item.height = 46;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 12, 50, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item96;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boldsum>();
			Item.buffType = ModContent.BuffType<boldBuff>();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Placeable.Rock>(), 36);
			recipe.AddIngredient(ModContent.ItemType<Items.Weapon.Summon.Minion2>(), 1);
			recipe.AddIngredient(ItemID.Bone, 36);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}