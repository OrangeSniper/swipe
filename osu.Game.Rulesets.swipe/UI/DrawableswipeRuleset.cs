// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Input.Handlers;
using osu.Game.Replays;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.swipe.Objects;
using osu.Game.Rulesets.swipe.Objects.Drawables;
using osu.Game.Rulesets.swipe.Replays;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.swipe.UI
{
    [Cached]
    public class DrawableswipeRuleset : DrawableRuleset<swipeHitObject>
    {
        public DrawableswipeRuleset(swipeRuleset ruleset, IBeatmap beatmap, IReadOnlyList<Mod> mods = null)
            : base(ruleset, beatmap, mods)
        {
        }

        public override PlayfieldAdjustmentContainer CreatePlayfieldAdjustmentContainer() => new swipePlayfieldAdjustmentContainer();

        protected override Playfield CreatePlayfield() => new swipePlayfield();

        protected override ReplayInputHandler CreateReplayInputHandler(Replay replay) => new swipeFramedReplayInputHandler(replay);

        public override DrawableHitObject<swipeHitObject> CreateDrawableRepresentation(swipeHitObject h) => new DrawableswipeHitObject(h);

        protected override PassThroughInputManager CreateInputManager() => new swipeInputManager(Ruleset?.RulesetInfo);
    }
}
