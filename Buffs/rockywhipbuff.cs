using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Buffs
{
    public class rockywhipbuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<rockyWhipDebuffNPC>().markedByrockyWhip = true;
        }
    }

    public class rockyWhipDebuffNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool markedByrockyWhip;

        public override void ResetEffects(NPC npc)
        {
            markedByrockyWhip = false;
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (markedByrockyWhip && !projectile.npcProj && !projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type]))
            {
                damage += 12;
            }
        }
    }
}
