using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Accesories
{
    public class Blindfold : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandy Blindfold");
            Tooltip.SetDefault("Sand gets in your eye when you put it on"
                + "\n +10% Acceleration + 5% RangedCrit");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 28;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 4, 45, 0);
            Item.rare = ItemRarityID.Orange;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed += .10f;
            player.GetCritChance(DamageClass.Ranged) += 5;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Bone, 26)
            .AddIngredient(ItemID.AntlionMandible, 6)
            .AddIngredient(ItemID.SandBlock, 30)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
