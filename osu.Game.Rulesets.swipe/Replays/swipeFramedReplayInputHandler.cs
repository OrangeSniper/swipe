﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using System.Diagnostics;
using osu.Framework.Input.StateChanges;
using osu.Framework.Utils;
using osu.Game.Replays;
using osu.Game.Rulesets.Replays;
using osuTK;

namespace osu.Game.Rulesets.swipe.Replays
{
    public class swipeFramedReplayInputHandler : FramedReplayInputHandler<swipeReplayFrame>
    {
        public swipeFramedReplayInputHandler(Replay replay)
            : base(replay)
        {
        }

        protected override bool IsImportant(swipeReplayFrame frame) => true;

        protected Vector2 Position
        {
            get
            {
                var frame = CurrentFrame;

                if (frame == null)
                    return Vector2.Zero;

                Debug.Assert(CurrentTime != null);

                return NextFrame != null ? Interpolation.ValueAt(CurrentTime.Value, frame.Position, NextFrame.Position, frame.Time, NextFrame.Time) : frame.Position;
            }
        }

        public override void GetPendingInputs()
        {
            inputs.Add(new MousePositionAbsoluteInput
            {
                new MousePositionAbsoluteInput
                {
                    Position = GamefieldToScreenSpace(Position)
                }
            };
        }
    }
}
