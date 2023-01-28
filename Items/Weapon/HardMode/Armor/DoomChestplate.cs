using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class DoomChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Praetor Suit");
            Tooltip.SetDefault("Heals on enemy strike"
                             + "\n + 8% Damage reduction");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;
            Item.value = Item.buyPrice(0, 11, 50, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.defense = 20;
        }
        public override void UpdateEquip(Player player)
        {
            player.onHitRegen = true;
            player.endurance = .08f - (0.1f * (1f - player.endurance));
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MartianUniformTorso, 1)
            .AddIngredient(ItemID.ChlorophyteBar, 12)
            .AddIngredient(ItemID.SpectreBar, 12)
            .AddIngredient(ItemID.HallowedBar, 12)
            .AddIngredient(ItemID.SoulofFright, 16)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}