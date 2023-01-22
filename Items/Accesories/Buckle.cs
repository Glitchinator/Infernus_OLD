using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Accesories
{
    public class Buckle : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Burning Buckle");
            Tooltip.SetDefault("Warmth pulses from it"
                + "\n +10% Melee Speed +5 Melee Crit");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 4, 45, 0);
            Item.rare = ItemRarityID.Orange;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Melee) += .10f;
            player.GetCritChance(DamageClass.Melee) += 5;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HellstoneBar, 16)
            .AddIngredient(ItemID.Bone, 26)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
