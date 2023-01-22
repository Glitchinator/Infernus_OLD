using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Accessories
{
    public class HiveHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hive Heart");
            Tooltip.SetDefault("Ripped from a guardian of the hive."
                  + "\n + Immune to venom and poisoned"
                  + "\n - 100 health, + 12% Damage"
                  + "\n + 8% Damage reduction, + 12% Crit"
                  + "\n + Increases the strength of bees"
                    + "\n Minor increase to life regen");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.value = Item.buyPrice(0, 14, 25, 0);
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegenCount += 5;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Venom] = true;
            player.strongBees = true;
            player.GetCritChance(DamageClass.Generic) += 12;
            player.GetDamage(DamageClass.Generic) += .12f;
            player.statLifeMax2 -= 100;
            player.endurance = .08f - (0.1f * (1f - player.endurance));
        }
    }
}