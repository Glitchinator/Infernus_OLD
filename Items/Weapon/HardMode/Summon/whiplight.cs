using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Summon
{
	public class whiplight : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Crackle n' Pop");
			Tooltip.SetDefault("Throw two whips one named Crackle and the other Pop"
				+"\n Your minions will attack struck foes"
							+ "\n + Frostburn and Fire");
		}

		public override void SetDefaults()
		{
			Item.DefaultToWhip(ModContent.ProjectileType<Infernus.Projectiles.Whipele>(), 110, 3, 7);
			Item.value = Item.buyPrice(0, 27, 50, 0);
			Item.useTime = 10;

			Item.shootSpeed = 9;
			Item.rare = ItemRarityID.Yellow;
		}
		public override bool MeleePrefix()
		{
			return true;
		}
	}
}