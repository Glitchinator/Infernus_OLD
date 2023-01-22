using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Accesories
{
    public class Charge : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Charger");
            Tooltip.SetDefault("+10% Summon damage");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 44;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 4, 65, 0);
            Item.rare = ItemRarityID.Green;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Summon) += .1f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Throwing>(), 1)
            .AddIngredient(ItemID.Obsidian, 8)
            .AddIngredient(ItemID.TissueSample, 8)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
