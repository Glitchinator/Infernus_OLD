using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Invas
{
    public class BoulderInvasion
    {
        public static int[] PHMInvaders = {
            ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder1").Type,
            ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder2").Type,
            ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder3").Type,
            ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder4").Type,
            ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder5").Type
        };

        public static int[] HMInvaders = {
            ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder1jung").Type,
            ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder2jung").Type,
            ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder3jung").Type,
            NPCID.RockGolem,
            NPCID.MossHornet,
        };

        public static int[] BossInvasion = {
            ModLoader.GetMod("Infernus").Find<ModNPC>("Boulderminiboss").Type
        };
        public static int[] GetBossNOW()
        {
            int[] list = new int[BossInvasion.Length];

            BossInvasion.CopyTo(list, 0);

            return list;
        }

        public static int[] GetInvadersNOW()
        {
            int[] list = new int[PHMInvaders.Length + HMInvaders.Length];

            PHMInvaders.CopyTo(list, 0);
            HMInvaders.CopyTo(list, PHMInvaders.Length);

            return list;
        }

        public static void StartBoulderInvasion()
        {
            if (Main.invasionType != 0 && Main.invasionSize == 0)
            {
                Main.invasionType = 0;
            }
            if (Main.invasionType == 0)
            {
                int num = 0;
                for (int i = 0; i < 255; i++)
                {
                    if (Main.player[i].active)
                    {
                        num++;
                    }
                }
                if (num > 0)
                {
                    Main.invasionType = -1;
                    InfernusWorld.BoulderInvasionUp = true;
                    Main.invasionSize = 100 * num;
                    Main.invasionSizeStart = Main.invasionSize;
                    Main.invasionProgress = 0;
                    Main.invasionProgressIcon = 0 + 3;
                    Main.invasionProgressWave = 0;
                    Main.invasionProgressMax = Main.invasionSizeStart;
                    Main.invasionWarn = 60;
                    if (Main.rand.NextBool(2))
                    {
                        Main.invasionX = 0.0;
                        return;
                    }
                    Main.invasionX = Main.maxTilesX;
                }
            }
        }
        public static void BoulderInvasionWarning()
        {
            if (Main.invasionX == Main.spawnTileX)
            {
                Main.NewText("An onslaught of rock and earth approaches from the west.", 207, 196, 162);
            }
            if (Main.invasionSize <= 0)
            {
                Main.NewText("The boulders leave, tunneling back into the ground.", 207, 196, 162);
            }
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                return;
            }
        }

        public static void UpdateBoulderInvasion()
        {
            if (InfernusWorld.BoulderInvasionUp)
            {
                if (Main.invasionSize <= 0)
                {
                    InfernusWorld.BoulderInvasionUp = false;
                    BoulderInvasionWarning();
                    Main.invasionType = 0;
                    Main.invasionDelay = 0;
                }
                if (Main.invasionX == Main.spawnTileX)
                {
                    return;
                }
                float num = (float)Main.dayRate;
                if (Main.invasionX > Main.spawnTileX)
                {
                    Main.invasionX -= num;
                    if (Main.invasionX <= Main.spawnTileX)
                    {
                        Main.invasionX = Main.spawnTileX;
                        BoulderInvasionWarning();
                    }
                    else
                    {
                        Main.invasionWarn--;
                    }
                }
                else
                {
                    if (Main.invasionX < Main.spawnTileX)
                    {
                        Main.invasionX += num;
                        if (Main.invasionX >= Main.spawnTileX)
                        {
                            Main.invasionX = Main.spawnTileX;
                            BoulderInvasionWarning();
                        }
                        else
                        {
                            Main.invasionWarn--;
                        }
                    }
                }
            }
        }

        public static void CheckInvasionProgress()
        {
            int[] FullList = GetInvadersNOW();

            if (Main.invasionProgressMode != 2)
            {
                Main.invasionProgressNearInvasion = false;
                return;
            }
            bool flag = false;
            Player player = Main.player[Main.myPlayer];
            Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
            int num = 5000;
            int icon = 0;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active)
                {
                    icon = 0;
                    int type = Main.npc[i].type;
                    for (int n = 0; n < FullList.Length; n++)
                    {
                        if (type == FullList[n])
                        {
                            Rectangle value = new Rectangle((int)(Main.npc[i].position.X + (Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (Main.npc[i].height / 2)) - num, num * 2, num * 2);
                            if (rectangle.Intersects(value))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }
            }
            Main.invasionProgressNearInvasion = flag;
            int progressMax3 = 1;
            if (InfernusWorld.BoulderInvasionUp)
            {
                progressMax3 = Main.invasionSizeStart;
            }
            if (InfernusWorld.BoulderInvasionUp && (Main.invasionX == Main.spawnTileX))
            {
                Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, progressMax3, icon, 0);
            }

            foreach (Player p in Main.player)
            {
                NetMessage.SendData(MessageID.InvasionProgressReport, p.whoAmI, -1, null, Main.invasionSizeStart - Main.invasionSize, Main.invasionSizeStart, (Main.invasionType + 3), 0f, 0, 0, 0);
            }
        }
    }
}
