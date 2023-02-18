using Infernus.Buffs;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Accesories
{
    [AutoloadEquip(EquipType.Back)]
    public class Shiny : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Raiko's Toothpaste");
            Tooltip.SetDefault("Enhanced mobility");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 4, 45, 0);
            Item.rare = ItemRarityID.Expert;
            Item.expert = true;
            Item.defense = 2;
            //Item.buffType = ModContent.BuffType<Meteor_Buff>();
           // Item.shoot = ModContent.ProjectileType<Projectiles.Meteor_Ring>();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += .08f;
            player.maxRunSpeed += .08f;
            player.hasJumpOption_WallOfFleshGoat = true;
            player.jumpSpeedBoost += .08f;
           // player.AddBuff(Item.buffType, 2);
        }
        public override void UpdateEquip(Player player)
        {
           // Main.LocalPlayer.GetModPlayer<InfernusPlayer>().Meteor_Storm_Active = true;
        }
    }
}
