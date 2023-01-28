using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Summon
{
    public class Drillxwhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Giant's Drill");
            Tooltip.SetDefault("Belonged to Drill-X"
                + "\n Your minions will attack struck foes"
                            + "\n + Explosions"
                            + "\n + 14 summon tag damage");
        }

        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<Projectiles.Drillx>(), 160, 3, 7);
            Item.value = Item.buyPrice(0, 30, 50, 0);

            Item.shootSpeed = 10;
            Item.rare = ItemRarityID.Yellow;
        }
        public override bool MeleePrefix()
        {
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Drax, 1)
            .AddIngredient(ItemID.ChlorophyteDrill, 1)
            .AddIngredient(ItemID.LaserDrill, 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}