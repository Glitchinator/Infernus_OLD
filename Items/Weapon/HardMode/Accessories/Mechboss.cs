using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Accessories
{
    public class Mechboss : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Mind");
            Tooltip.SetDefault("Detection,+10% pickspeed,+1 speed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 26;
            Item.value = Item.buyPrice(0, 14, 25, 0);
            Item.rare = ItemRarityID.Expert;
            Item.defense = 6;
            Item.expert = true;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.boneArmor = true;
            player.detectCreature = true;
            player.armorEffectDrawShadow = true;
            player.pickSpeed += .1f;
            player.accRunSpeed += 1;
            player.dangerSense = true;

        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MechanicalBatteryPiece, 1)
            .AddIngredient(ItemID.MechanicalWagonPiece, 1)
            .AddIngredient(ItemID.MechanicalWheelPiece, 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}