using System.ComponentModel;

namespace Library.SystemModels
{
	public enum MiniGames
	{
        [Description("争夺小游戏")]
        [Category("两个对立的队。第一个夺取并将对方旗帜送回领奖台的队伍获胜.")]
        CaptureTheFlag,
        [Description("金银岛")]
        [Category("每个人都想在岛上生存下去。要么是最后一个被困的玩家，要么是最后一个还活着的玩家，以便能够找到隐藏的宝藏.")]
        TreasureIsland,
        [Description("怪打网球")]
        [Category("杀死怪物的速度比你的对手快。每次你杀死一个怪物，它都会在对方的队伍中重生。成为最后一支赢得比赛的队伍.")]
        MonsterTennis,
        [Description("激烈的战争")]
        [Category("每个玩家都是为了自己。最后3名站着的玩家将获得前3名杀手的奖励.")]
        BattleRoyal,
        [Description("团队激战")]
        [Category("两队决一雌雄。为了生存和赚钱而杀人。最后站着的队伍是赢家，每个队伍的前两名杀手都有奖金奖励.")]
        TeamBattleRoyal
    }
}
