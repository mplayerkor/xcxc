using System;
using System.Collections.Generic;
using System.Drawing;Blitzcrank_



using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using Color = System.Drawing.Color;

namespace FreshBooster
{
    class FreshCommon
    {
        public static Menu _MainMenu;
        public static Orbwalking.Orbwalker _OrbWalker;
        public static int TickCount(int time)
        {
            return Environment.TickCount + time;
        }
        public static int NowTime()
        {
            return Environment.TickCount;
        }
        public static HitChance Hitchance(string Type)
        {
            HitChance result = HitChance.Low;
            switch (_MainMenu.Item(Type).GetValue<Slider>().Value)
            {
                case 1:
                    result = HitChance.OutOfRange;
                    break;
                case 2:
                    result = HitChance.Impossible;
                    break;
                case 3:
                    result = HitChance.Low;
                    break;
                case 4:
                    result = HitChance.Medium;
                    break;
                case 5:
                    result = HitChance.High;
                    break;
                case 6:
                    result = HitChance.VeryHigh;
                    break;
            }
            return result;
        }
        public static Obj_AI_Base GetFindObj(string name, float range, Vector3 Pos)
        {
            var CusPos = Pos;
            if (ObjectManager.Player.Distance(CusPos) > range) CusPos = ObjectManager.Player.Position.Extend(Game.CursorPos, range);
            var GetObj = ObjectManager.Get<Obj_AI_Base>().FirstOrDefault(f => f.IsAlly && !f.IsMe && f.Position.Distance(ObjectManager.Player.Position) < range && f.Distance(CusPos) < 150);
            if (GetObj != null)
                return GetObj;
            return null;
        }
        public static void MovingPlayer(Vector3 Pos)
        {
            ObjectManager.Player.IssueOrder(GameObjectOrder.MoveTo, Pos);
        }
        public static Vector2 ToScreen(Vector3 Target)
        {
            var target = Drawing.WorldToScreen(Target);
            return target;
        }
        public static bool HasBuff(Obj_AI_Hero Hero)
        {
            if (Hero.HasBuffOfType(BuffType.Flee))
                return true;
            if (Hero.HasBuffOfType(BuffType.Charm))
                return true;
            if (Hero.HasBuffOfType(BuffType.Polymorph))
                return true;
            if (Hero.HasBuffOfType(BuffType.Snare))
                return true;
            if (Hero.HasBuffOfType(BuffType.Stun))
                return true;
            if (Hero.HasBuffOfType(BuffType.Taunt))
                return true;
            if (Hero.HasBuffOfType(BuffType.Suppression))
                return true;
            return false;
        }
        public static Color LineColor(Obj_AI_Hero Hero)
        {
            if (Hero.HealthPercent <= 10)
                return Color.Red;
            if (Hero.HealthPercent <= 25)
                return Color.OrangeRed;
            if (Hero.HealthPercent <= 35)
                return Color.Yellow;
            if (Hero.HealthPercent <= 45)
                return Color.YellowGreen;
            if (Hero.HealthPercent <= 60)
                return Color.Green;
            return Color.Green;
        }
    }
}