using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Summon
{
	public class Whiprock : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Rumble Crunch");
			Tooltip.SetDefault("Your minions will attack struck foes"
							+ "\n + Venom and boulders");
		}

		public override void SetDefaults()
		{
			Item.DefaultToWhip(ModContent.ProjectileType<Infernus.Projectiles.Whiprock>(), 140, 3, 7);
			Item.value = Item.buyPrice(0, 18, 50, 0);

			Item.shootSpeed = 8;
			Item.rare = ItemRarityID.Lime;
		}
		public override bool MeleePrefix()
		{
			return true;
		}
	}
}