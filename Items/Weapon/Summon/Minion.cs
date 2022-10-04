using Infernus.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.Summon
{
	public class Minion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Raiko's Flame");
			Tooltip.SetDefault("Summon a flame that engulfs you, shots homing flame projectiles, can only summon one");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 10;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 8, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item96;
			Item.shoot = ModContent.ProjectileType<Projectiles.Minion2>();
			Item.buffType = ModContent.BuffType<RaikoBuff>();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
	}
}