using Infernus.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.Summon
{
    public class Dunger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dunger");
            Tooltip.SetDefault("Summon a bouncing pile of bones");
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.DamageType = DamageClass.Summon;
            Item.mana = 8;
            Item.width = 42;
            Item.height = 42;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.knockBack = 3f;
            Item.value = Item.buyPrice(0, 9, 50, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item96;
            Item.shoot = ModContent.ProjectileType<Projectiles.Dunger>();
            Item.buffType = ModContent.BuffType<DungBuff>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Bone, 48)
            .AddIngredient(ItemID.Cobweb, 26)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}