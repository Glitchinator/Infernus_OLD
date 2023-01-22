using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Tools
{
    public class Magic9Ball : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magic Nine Ball");
            Tooltip.SetDefault("Shake to show your character's stats");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 2;
        }
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 34;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = 0;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Master;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .Register();
        }
        public override bool? UseItem(Player player)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<InfernusPlayer>();
            if (modPlayer.Level_Score == 1)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "5% Increased Pickspeed", true);
            }
            if (modPlayer.Level_Score == 2)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "5% Increased Pickspeed" + "\n +1 Mining Range", true);
            }
            if (modPlayer.Level_Score == 3)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "5% Increased Pickspeed" + "\n +1 Mining Range" + "\n +1 Life Regen", true);
            }
            if (modPlayer.Level_Score == 4)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "5% Increased Pickspeed" + "\n +1 Mining Range" + "\n +1 Life Regen" + "\n 6% Increased Runspeed", true);
            }
            if (modPlayer.Level_Score == 5)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "5% Increased Pickspeed" + "\n +1 Mining Range" + "\n +1 Life Regen" + "\n 6% Increased Runspeed" + "\n +2 Fishing Power", true);
            }
            if (modPlayer.Level_Score == 6)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "5% Increased Pickspeed" + "\n +1 Mining Range" + "\n +1 Life Regen" + "\n 6% Increased Runspeed" + "\n +2 Fishing Power" + "\n 2% Increased Damage", true);
            }
            if (modPlayer.Level_Score == 7)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "5% Increased Pickspeed" + "\n +1 Mining Range" + "\n +1 Life Regen" + "\n 6% Increased Runspeed" + "\n +2 Fishing Power" + "\n 2% Increased Damage" + "\n +1 Placing Range", true);
            }
            if (modPlayer.Level_Score == 8)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +1 Mining Range" + "\n +1 Life Regen" + "\n 6% Increased Runspeed" + "\n +2 Fishing Power" + "\n 2% Increased Damage" + "\n +1 Placing Range", true);
            }
            if (modPlayer.Level_Score == 9)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +1 Mining Range" + "\n +1 Life Regen" + "\n 8% Increased Runspeed" + "\n +2 Fishing Power" + "\n 2% Increased Damage" + "\n +1 Placing Range", true);
            }
            if (modPlayer.Level_Score == 10)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +1 Mining Range" + "\n +1 Life Regen" + "\n 8% Increased Runspeed" + "\n +2 Fishing Power" + "\n 2% Increased Damage" + "\n +1 Placing Range" + "\n +2 Defense", true);
            }
            if (modPlayer.Level_Score == 11)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +1 Mining Range" + "\n +1 Life Regen" + "\n 8% Increased Runspeed" + "\n +4 Fishing Power" + "\n 2% Increased Damage" + "\n +1 Placing Range" + "\n +2 Defense", true);
            }
            if (modPlayer.Level_Score == 12)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +1 Mining Range" + "\n +3 Life Regen" + "\n 8% Increased Runspeed" + "\n +4 Fishing Power" + "\n 2% Increased Damage" + "\n +1 Placing Range" + "\n +2 Defense", true);
            }
            if (modPlayer.Level_Score == 13)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +1 Mining Range" + "\n +3 Life Regen" + "\n 8% Increased Runspeed" + "\n +4 Fishing Power" + "\n 2% Increased Damage" + "\n +2 Placing Range" + "\n +2 Defense", true);
            }
            if (modPlayer.Level_Score == 14)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +1 Mining Range" + "\n +3 Life Regen" + "\n 8% Increased Runspeed" + "\n +4 Fishing Power" + "\n 2% Increased Damage" + "\n +2 Placing Range" + "\n +2 Defense" + "\n +2% Damage Reduction", true);
            }
            if (modPlayer.Level_Score == 15)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +2 Mining Range" + "\n +3 Life Regen" + "\n 8% Increased Runspeed" + "\n +4 Fishing Power" + "\n 2% Increased Damage" + "\n +2 Placing Range" + "\n +2 Defense" + "\n +2% Damage Reduction", true);
            }
            if (modPlayer.Level_Score == 16)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +2 Mining Range" + "\n +3 Life Regen" + "\n 10% Increased Runspeed" + "\n +4 Fishing Power" + "\n 2% Increased Damage" + "\n +2 Placing Range" + "\n +2 Defense" + "\n +2% Damage Reduction", true);
            }
            if (modPlayer.Level_Score == 17)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +2 Mining Range" + "\n +3 Life Regen" + "\n 10% Increased Runspeed" + "\n +4 Fishing Power" + "\n 4% Increased Damage" + "\n +2 Placing Range" + "\n +2 Defense" + "\n +2% Damage Reduction", true);
            }
            if (modPlayer.Level_Score == 18)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +2 Mining Range" + "\n +3 Life Regen" + "\n 10% Increased Runspeed" + "\n +4 Fishing Power" + "\n 4% Increased Damage" + "\n +2 Placing Range" + "\n +2 Defense" + "\n +3% Damage Reduction", true);
            }
            if (modPlayer.Level_Score == 19)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +2 Mining Range" + "\n +3 Life Regen" + "\n 10% Increased Runspeed" + "\n +4 Fishing Power" + "\n 4% Increased Damage" + "\n +2 Placing Range" + "\n +2 Defense" + "\n +3% Damage Reduction" + "\n +2 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 20)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +2 Mining Range" + "\n +3 Life Regen" + "\n 10% Increased Runspeed" + "\n +4 Fishing Power" + "\n 4% Increased Damage" + "\n +2 Placing Range" + "\n +4 Defense" + "\n +3% Damage Reduction" + "\n +2 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 21)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +2 Mining Range" + "\n +3 Life Regen" + "\n 10% Increased Runspeed" + "\n +4 Fishing Power" + "\n 4% Increased Damage" + "\n +2 Placing Range" + "\n +4 Defense" + "\n +3% Damage Reduction" + "\n +4 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 22)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "10% Increased Pickspeed" + "\n +2 Mining Range" + "\n +4 Life Regen" + "\n 10% Increased Runspeed" + "\n +4 Fishing Power" + "\n 4% Increased Damage" + "\n +2 Placing Range" + "\n +4 Defense" + "\n +3% Damage Reduction" + "\n +4 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 23)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +2 Mining Range" + "\n +4 Life Regen" + "\n 10% Increased Runspeed" + "\n +4 Fishing Power" + "\n 4% Increased Damage" + "\n +2 Placing Range" + "\n +4 Defense" + "\n +3% Damage Reduction" + "\n +4 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 24)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +2 Mining Range" + "\n +4 Life Regen" + "\n 10% Increased Runspeed" + "\n +6 Fishing Power" + "\n 4% Increased Damage" + "\n +2 Placing Range" + "\n +4 Defense" + "\n +3% Damage Reduction" + "\n +4 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 25)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +2 Mining Range" + "\n +4 Life Regen" + "\n 10% Increased Runspeed" + "\n +6 Fishing Power" + "\n 6% Increased Damage" + "\n +2 Placing Range" + "\n +4 Defense" + "\n +3% Damage Reduction" + "\n +4 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 26)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +2 Mining Range" + "\n +4 Life Regen" + "\n 10% Increased Runspeed" + "\n +8 Fishing Power" + "\n 6% Increased Damage" + "\n +2 Placing Range" + "\n +4 Defense" + "\n +3% Damage Reduction" + "\n +4 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 27)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +2 Mining Range" + "\n +4 Life Regen" + "\n 10% Increased Runspeed" + "\n +8 Fishing Power" + "\n 6% Increased Damage" + "\n +2 Placing Range" + "\n +4 Defense" + "\n +3% Damage Reduction" + "\n +6 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 28)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +2 Mining Range" + "\n +4 Life Regen" + "\n 10% Increased Runspeed" + "\n +8 Fishing Power" + "\n 6% Increased Damage" + "\n +3 Placing Range" + "\n +4 Defense" + "\n +3% Damage Reduction" + "\n +6 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 29)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +2 Mining Range" + "\n +4 Life Regen" + "\n 12% Increased Runspeed" + "\n +8 Fishing Power" + "\n 6% Increased Damage" + "\n +3 Placing Range" + "\n +4 Defense" + "\n +3% Damage Reduction" + "\n +6 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 30)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +2 Mining Range" + "\n +4 Life Regen" + "\n 12% Increased Runspeed" + "\n +8 Fishing Power" + "\n 6% Increased Damage" + "\n +3 Placing Range" + "\n +6 Defense" + "\n +3% Damage Reduction" + "\n +6 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 31)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +2 Mining Range" + "\n +4 Life Regen" + "\n 12% Increased Runspeed" + "\n +10 Fishing Power" + "\n 6% Increased Damage" + "\n +3 Placing Range" + "\n +6 Defense" + "\n +3% Damage Reduction" + "\n +6 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 32)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 12% Increased Runspeed" + "\n +10 Fishing Power" + "\n 6% Increased Damage" + "\n +3 Placing Range" + "\n +6 Defense" + "\n +3% Damage Reduction" + "\n +6 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 33)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 12% Increased Runspeed" + "\n +10 Fishing Power" + "\n 6% Increased Damage" + "\n +3 Placing Range" + "\n +6 Defense" + "\n +5% Damage Reduction" + "\n +6 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 34)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 18% Increased Runspeed" + "\n +10 Fishing Power" + "\n 6% Increased Damage" + "\n +3 Placing Range" + "\n +6 Defense" + "\n +5% Damage Reduction" + "\n +6 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 35)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 18% Increased Runspeed" + "\n +12 Fishing Power" + "\n 6% Increased Damage" + "\n +3 Placing Range" + "\n +6 Defense" + "\n +5% Damage Reduction" + "\n +6 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 36)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 18% Increased Runspeed" + "\n +12 Fishing Power" + "\n 8% Increased Damage" + "\n +3 Placing Range" + "\n +6 Defense" + "\n +5% Damage Reduction" + "\n +6 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 37)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "15% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 18% Increased Runspeed" + "\n +12 Fishing Power" + "\n 8% Increased Damage" + "\n +3 Placing Range" + "\n +6 Defense" + "\n +5% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 38)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 18% Increased Runspeed" + "\n +12 Fishing Power" + "\n 8% Increased Damage" + "\n +3 Placing Range" + "\n +6 Defense" + "\n +5% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 39)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 20% Increased Runspeed" + "\n +12 Fishing Power" + "\n 8% Increased Damage" + "\n +3 Placing Range" + "\n +6 Defense" + "\n +5% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 40)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 20% Increased Runspeed" + "\n +12 Fishing Power" + "\n 8% Increased Damage" + "\n +3 Placing Range" + "\n +8 Defense" + "\n +5% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 41)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 20% Increased Runspeed" + "\n +14 Fishing Power" + "\n 8% Increased Damage" + "\n +3 Placing Range" + "\n +8 Defense" + "\n +5% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 42)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 20% Increased Runspeed" + "\n +16 Power" + "\n 8% Increased Damage" + "\n +3 Placing Range" + "\n +8 Defense" + "\n +5% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 43)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 20% Increased Runspeed" + "\n +16 Fishing Power" + "\n 8% Increased Damage" + "\n +4 Placing Range" + "\n +8 Defense" + "\n +5% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 44)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +3 Mining Range" + "\n +4 Life Regen" + "\n 20% Increased Runspeed" + "\n +16 Fishing Power" + "\n 8% Increased Damage" + "\n +4 Placing Range" + "\n +8 Defense" + "\n +7% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 45)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +4 Mining Range" + "\n +4 Life Regen" + "\n 20% Increased Runspeed" + "\n +16 Fishing Power" + "\n 8% Increased Damage" + "\n +4 Placing Range" + "\n +8 Defense" + "\n +7% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 46)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +4 Mining Range" + "\n +4 Life Regen" + "\n 22% Increased Runspeed" + "\n +16 Fishing Power" + "\n 8% Increased Damage" + "\n +4 Placing Range" + "\n +8 Defense" + "\n +7% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 47)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +4 Mining Range" + "\n +4 Life Regen" + "\n 22% Increased Runspeed" + "\n +16 Fishing Power" + "\n 10% Increased Damage" + "\n +4 Placing Range" + "\n +8 Defense" + "\n +7% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 48)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +4 Mining Range" + "\n +4 Life Regen" + "\n 22% Increased Runspeed" + "\n +16 Fishing Power" + "\n 10% Increased Damage" + "\n +4 Placing Range" + "\n +8 Defense" + "\n +8% Damage Reduction" + "\n +8 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 49)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +4 Mining Range" + "\n +4 Life Regen" + "\n 22% Increased Runspeed" + "\n +16 Fishing Power" + "\n 10% Increased Damage" + "\n +4 Placing Range" + "\n +8 Defense" + "\n +8% Damage Reduction" + "\n +10 Crit Chance", true);
            }
            if (modPlayer.Level_Score == 50)
            {
                CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), InfernusPlayer.GainXP_Resource, "20% Increased Pickspeed" + "\n +4 Mining Range" + "\n +4 Life Regen" + "\n 22% Increased Runspeed" + "\n +16 Fishing Power" + "\n 10% Increased Damage" + "\n +4 Placing Range" + "\n +10 Defense" + "\n +8% Damage Reduction" + "\n +10 Crit Chance", true);
            }
            return true;
        }
    }
}