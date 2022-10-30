using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Melee
{
    public class Trueprimed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prime Light's Edge");
            Tooltip.SetDefault("spawns 3 shards when fully thrown,Shoots white daggers at enemies, has a chance to spawn daggers on hit, inflicts venom");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 55;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.width = 30;
            Item.height = 32;
            Item.useTime = 28;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 0;
            Item.value = Item.buyPrice(0, 36, 50, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.crit = 8;
            Item.shoot = ModContent.ProjectileType<Projectiles.LightTruePrimed>();
            Item.channel = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Weapon.HardMode.Melee.TrueLight>(), 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.Rock>(), 26);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
        }
    }
}
