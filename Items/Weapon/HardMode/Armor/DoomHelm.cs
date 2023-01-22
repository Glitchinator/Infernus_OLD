using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class DoomHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Praetor Helm");
            Tooltip.SetDefault("Immune to knockback"
                             + "\n Enemies are more likely"
                             + "\n to target you");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 20;
            Item.value = Item.buyPrice(0, 11, 50, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.defense = 31;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += .20f;
            player.aggro += 25;
            player.noKnockback = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<DoomChestplate>() && legs.type == ModContent.ItemType<DoomLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Blood Pact" + "\n + Dash" + "\n + No Fall Damage" + "\n + Better Movement";
            player.GetModPlayer<InfernusPlayer>().DoomDash = true;
            player.noFallDmg = true;
            player.moveSpeed += .6f;
            player.jumpSpeedBoost += .4f;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MartianUniformHelmet, 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
            recipe.AddIngredient(ItemID.SpectreBar, 8);
            recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.AddIngredient(ItemID.SoulofSight, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}