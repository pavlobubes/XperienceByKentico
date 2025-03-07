using System.ComponentModel;

namespace DancingGoat.Web.Components.Sections.Enums;

public enum CornerStyleOption
{
    [Description("Sharp corners")]
    Sharp = 0,

    [Description("Round corners")]
    Round = 1,

    [Description("Very round corners")]
    VeryRound = 2,
}