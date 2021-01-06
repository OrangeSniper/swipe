// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Replays;
using osu.Game.Rulesets.swipe.Objects;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.swipe.Replays
{
    public class swipeAutoGenerator : AutoGenerator
    {
        protected Replay Replay;
        protected List<ReplayFrame> Frames => Replay.Frames;

        public new Beatmap<swipeHitObject> Beatmap => (Beatmap<swipeHitObject>)base.Beatmap;

        public swipeAutoGenerator(IBeatmap beatmap)
            : base(beatmap)
        {
            Replay = new Replay();
        }

        public override Replay Generate()
        {
            Frames.Add(new swipeReplayFrame());

            foreach (swipeHitObject hitObject in Beatmap.HitObjects)
            {
                Frames.Add(new swipeReplayFrame
                {
                    Time = hitObject.StartTime,
                    Position = hitObject.Position,
                });
            }

            return Replay;
        }
    }
}
