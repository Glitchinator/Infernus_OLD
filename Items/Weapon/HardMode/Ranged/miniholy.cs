using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Ranged
{
	public class miniholy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deliverer");
            Tooltip.SetDefault("This costs 130,000 platnium to fire for 1 minutes"
    + "\n 55% chance to not consume ammo");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 70;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 76;
			Item.height = 34;
			Item.useAnimation = 1;
			Item.useTime = 1;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(0, 37, 50, 0);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 22f;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 8;
		}
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .55f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(1));
		}
	}
}