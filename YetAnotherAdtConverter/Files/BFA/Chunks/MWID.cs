﻿using System;
using System.Collections.Generic;
using System.Text;
using YetAnotherAdtConverter.Files.WOTLK;

namespace YetAnotherAdtConverter.Files.BFA.Chunks
{
    class MWID : Chunk
    {
        List<UInt32> offsets = new List<UInt32>();
        public MWID(WOTLK.Chunks.MWID wotlk) : base(wotlk, false)
        {
            offsets = wotlk.Offsets;
        }

        public override byte[] GetBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(Header.GetBytes());

            foreach (int x in offsets)
            {
                bytes.AddRange(BitConverter.GetBytes(x));
            }

            return bytes.ToArray();
        }

        public override int RecalculateSize()
        {
            throw new NotImplementedException();
        }
    }
}