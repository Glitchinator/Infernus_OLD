using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Summon
{
    public class Whiprock : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Rumble Crunch");
            Tooltip.SetDefault("Your minions will attack struck foes"
                            + "\n + Venom and boulders"
                            + "\n + 12 summon tag damage");
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