using Infernus.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Infernus
{
    internal class InfernusPlayer : ModPlayer
    {
        // Doom Guy dash variables
        public const int DashRight = 2;
        public const int DashLeft = 3;
        public const int DashCooldown = 50;
        public const int DashDuration = 35;
        public const float DashVelocity = 16f;
        public int DashDir = -1;
        public bool DoomDash;
        public int DashDelay = 0;
        public int DashTimer = 0;

        // XP for level variables
        public int XP_Current;
        public const int DefaultXP_Max = 100;
        public int XP_Max;
        public int XP_Max2;
        public static readonly Color GainXP_Resource = new(247, 171, 72);

        // Level variables
        public int Level_Score;
        public const int DefaultLevel_Max = 50;
        public int Level_Max;
        public int Level_Max2;

        // Ink Storm Variable
        public bool Ink_Storm_Equipped = false;

        public override void ModifyNursePrice(NPC nurse, int health, bool removeDebuffs, ref int price)
        {
            if (Player.statLife < Player.statLifeMax)
            {
                price = 100;
            }
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if(Ink_Storm_Equipped == true)
            {
                if (Main.rand.Next(3) < 1)
                {
                    Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType<Ink_EmergencyTyphoon>(), 16, 0, 0);
                }
            }
        }
        public override void LoadData(TagCompound tag)
        {
            XP_Current = tag.GetInt("XP_Current");
            Level_Score = tag.GetInt("Level_Score");
        }
        public override void SaveData(TagCompound tag)
        {
            tag["XP_Current"] = XP_Current;
            tag["Level_Score"] = Level_Score;
        }
        public override void Initialize()
        {
            XP_Max = DefaultXP_Max;
            Level_Max = DefaultLevel_Max;
        }

        public override void UpdateDead()
        {
            ResetVariables();
            Level_Perks();
        }

        private void ResetVariables()
        {
            XP_Max2 = DefaultXP_Max;
            Level_Max2 = DefaultLevel_Max;
        }

        public override void PostUpdateMiscEffects()
        {
            UpdateResource();
            Level_Perks();
        }
        private void UpdateResource()
        {
            if (DownedBoss.Level_systemON == false)
            {
                return;
            }

            if (XP_Max == XP_Current)
            {
                XP_Current = 0;
                Level_Score += 1;

                SoundEngine.PlaySound(SoundID.AchievementComplete);

                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(Player.name + " has gained a level, blessed by the Infernal gods.", GainXP_Resource);
                }
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    Main.NewText(Player.name + " has gained a level, blessed by the Infernal gods.", GainXP_Resource);
                }
            }

            XP_Current = Utils.Clamp(XP_Current, 0, XP_Max2);
            Level_Score = Utils.Clamp(Level_Score, 0, Level_Max2);
        }

        public override void ResetEffects()
        {
            ResetVariables();

            DoomDash = false;

            if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[DashRight] < 15)
            {
                DashDir = DashRight;
            }
            else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[DashLeft] < 15)
            {
                DashDir = DashLeft;
            }
            else
            {
                DashDir = -1;
            }
        }

        public override void PreUpdateMovement()
        {
            if (CanUseDash() && DashDir != -1 && DashDelay == 0)
            {
                Vector2 newVelocity = Player.velocity;

                switch (DashDir)
                {
                    case DashLeft when Player.velocity.X > -DashVelocity:
                    case DashRight when Player.velocity.X < DashVelocity:
                        {
                            float dashDirection = DashDir == DashRight ? 1 : -1;
                            newVelocity.X = dashDirection * DashVelocity;
                            break;
                        }
                    default:
                        return;
                }

                DashDelay = DashCooldown;
                DashTimer = DashDuration;
                Player.velocity = newVelocity;

                SoundEngine.PlaySound(SoundID.NPCDeath14, Player.position);

            }

            if (DashDelay > 0)
                DashDelay--;

            if (DashTimer > 0)
            {
                DashTimer--;
            }
        }

        private bool CanUseDash()
        {
            return DoomDash
                && !Player.mount.Active;
        }
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {

            return new[] {
                new Item(ModContent.ItemType<Items.Consumable.StartingBag>(), 1)
            };
        }
        private void Level_Perks()
        {
            if (DownedBoss.Level_systemON == false)
            {
                return;
            }

            if (Level_Score >= 1)
            {
                Player.pickSpeed += .05f;
            }
            if (Level_Score >= 2)
            {
                Player.tileRangeX += 1;
                Player.tileRangeY += 1;
            }
            if (Level_Score >= 3)
            {
                Player.lifeRegen += 1;
            }
            if (Level_Score >= 4)
            {
                Player.moveSpeed += .06f;
                Player.maxRunSpeed += .06f;
            }
            if (Level_Score >= 5)
            {
                Player.fishingSkill += 2;
            }
            if (Level_Score >= 6)
            {
                Player.GetDamage(DamageClass.Generic) += .02f;
            }
            if (Level_Score >= 7)
            {
                Player.blockRange += 1;
            }
            if (Level_Score >= 8)
            {
                Player.pickSpeed += .05f;
            }
            if (Level_Score >= 9)
            {
                Player.moveSpeed += .02f;
                Player.maxRunSpeed += .02f;
            }
            if (Level_Score >= 10)
            {
                Player.statDefense += 2;
            }
            if (Level_Score >= 11)
            {
                Player.fishingSkill += 2;
            }
            if (Level_Score >= 12)
            {
                Player.lifeRegen += 2;
            }
            if (Level_Score >= 13)
            {
                Player.blockRange += 1;
            }
            if (Level_Score >= 14)
            {
                Player.endurance = .02f - (0.1f * (1f - Player.endurance));
            }
            if (Level_Score >= 15)
            {
                Player.tileRangeX += 1;
                Player.tileRangeY += 1;
            }
            if (Level_Score >= 16)
            {
                Player.moveSpeed += .02f;
                Player.maxRunSpeed += .02f;
            }
            if (Level_Score >= 17)
            {
                Player.GetDamage(DamageClass.Generic) += .02f;
            }
            if (Level_Score >= 18)
            {
                Player.endurance = .01f - (0.1f * (1f - Player.endurance));
            }
            if (Level_Score >= 19)
            {
                Player.GetCritChance(DamageClass.Generic) += 2;
            }
            if (Level_Score >= 20)
            {
                Player.statDefense += 2;
            }
            if (Level_Score >= 21)
            {
                Player.GetCritChance(DamageClass.Generic) += 2;
            }
            if (Level_Score >= 22)
            {
                Player.lifeRegen += 1;
            }
            if (Level_Score >= 23)
            {
                Player.pickSpeed += .05f;
            }
            if (Level_Score >= 24)
            {
                Player.fishingSkill += 2;
            }
            if (Level_Score >= 25)
            {
                Player.GetDamage(DamageClass.Generic) += .02f;
            }
            if (Level_Score >= 26)
            {
                Player.fishingSkill += 2;
            }
            if (Level_Score >= 27)
            {
                Player.GetCritChance(DamageClass.Generic) += 2;
            }
            if (Level_Score >= 28)
            {
                Player.blockRange += 1;
            }
            if (Level_Score >= 29)
            {
                Player.moveSpeed += .02f;
                Player.maxRunSpeed += .02f;
            }
            if (Level_Score >= 30)
            {
                Player.statDefense += 2;
            }
            if (Level_Score >= 31)
            {
                Player.fishingSkill += 2;
            }
            if (Level_Score >= 32)
            {
                Player.tileRangeX += 1;
                Player.tileRangeY += 1;
            }
            if (Level_Score >= 33)
            {
                Player.endurance = .02f - (0.1f * (1f - Player.endurance));
            }
            if (Level_Score >= 34)
            {
                Player.moveSpeed += .06f;
                Player.maxRunSpeed += .06f;
            }
            if (Level_Score >= 35)
            {
                Player.fishingSkill += 2;
            }
            if (Level_Score >= 36)
            {
                Player.GetDamage(DamageClass.Generic) += .02f;
            }
            if (Level_Score >= 37)
            {
                Player.GetCritChance(DamageClass.Generic) += 2;
            }
            if (Level_Score >= 38)
            {
                Player.pickSpeed += .05f;
            }
            if (Level_Score >= 39)
            {
                Player.moveSpeed += .02f;
                Player.maxRunSpeed += .02f;
            }
            if (Level_Score >= 40)
            {
                Player.statDefense += 2;
            }
            if (Level_Score >= 41)
            {
                Player.fishingSkill += 2;
            }
            if (Level_Score >= 42)
            {
                Player.fishingSkill += 2;
            }
            if (Level_Score >= 43)
            {
                Player.blockRange += 1;
            }
            if (Level_Score >= 44)
            {
                Player.endurance = .02f - (0.1f * (1f - Player.endurance));
            }
            if (Level_Score >= 45)
            {
                Player.tileRangeX += 1;
                Player.tileRangeY += 1;
            }
            if (Level_Score >= 46)
            {
                Player.moveSpeed += .02f;
                Player.maxRunSpeed += .02f;
            }
            if (Level_Score >= 47)
            {
                Player.GetDamage(DamageClass.Generic) += .02f;
            }
            if (Level_Score >= 48)
            {
                Player.endurance = .01f - (0.1f * (1f - Player.endurance));
            }
            if (Level_Score >= 49)
            {
                Player.GetCritChance(DamageClass.Generic) += 2;
            }
            if (Level_Score >= 50)
            {
                Player.statDefense += 2;
                Player.armorEffectDrawShadow = true;
            }
        }
    }
}