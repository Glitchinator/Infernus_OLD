using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Ranged
{
    public class nailgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boarder");
            Tooltip.SetDefault("you better buy more nails");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 78;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 60;
            Item.height = 30;
            Item.useAnimation = 5;
            Item.useTime = 5;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 19, 75, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = SoundID.Item108;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.useAmmo = AmmoID.NailFriendly;
            Item.shoot = ProjectileID.NailFriendly;
            Item.shootSpeed = 22f;
            Item.crit = 8;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}