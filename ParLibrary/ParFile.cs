﻿// -------------------------------------------------------
// © Kaplas. Licensed under MIT. See LICENSE for details.
// -------------------------------------------------------
namespace ParLibrary
{
    using System;
    using Yarhl.IO;

    /// <summary>
    /// Represents a file stored in a PAR archive.
    /// </summary>
    public class ParFile : BinaryFormat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParFile"/> class.
        /// </summary>
        public ParFile()
        {
            this.CanBeCompressed = true;
            this.IsCompressed = false;
            this.DecompressedSize = 0;
            this.Unknown1 = 0x00000020;
            this.Unknown2 = 0x00000000;
            this.Unknown3 = 0x00000000;
            this.FileDate = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParFile"/> class.
        /// </summary>
        /// <param name="stream">The data stream.</param>
        public ParFile(DataStream stream)
            : base(stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            this.CanBeCompressed = true;
            this.IsCompressed = false;
            this.DecompressedSize = (int)stream.Length;
            this.Unknown1 = 0x00000020;
            this.Unknown2 = 0x00000000;
            this.Unknown3 = 0x00000000;
            this.FileDate = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParFile"/> class.
        /// </summary>
        /// <param name="stream">The base stream.</param>
        /// <param name="offset">Start offset.</param>
        /// <param name="length">Data length.</param>
        public ParFile(DataStream stream, long offset, long length)
            : base(stream, offset, length)
        {
            this.CanBeCompressed = true;
            this.IsCompressed = false;
            this.DecompressedSize = (int)length;
            this.Unknown1 = 0x00000020;
            this.Unknown2 = 0x00000000;
            this.Unknown3 = 0x00000000;
            this.FileDate = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the file can be compressed.
        /// </summary>
        public bool CanBeCompressed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the file is compressed.
        /// </summary>
        public bool IsCompressed { get; set; }

        /// <summary>
        /// Gets or sets the file size (decompressed).
        /// </summary>
        public int DecompressedSize { get; set; }

        /// <summary>
        /// Gets or sets the file "unknown" value #1.
        /// </summary>
        public int Unknown1 { get; set; }

        /// <summary>
        /// Gets or sets the file "unknown" value #2.
        /// </summary>
        public int Unknown2 { get; set; }

        /// <summary>
        /// Gets or sets the file "unknown" value #3.
        /// </summary>
        public int Unknown3 { get; set; }

        /// <summary>
        /// Gets or sets the file date (as integer).
        /// </summary>
        public int Date { get; set; }

        /// <summary>
        /// Gets or sets the file date (as DateTime).
        /// </summary>
        public DateTime FileDate
        {
            get
            {
                var baseDate = new DateTime(1970, 1, 1);
                return baseDate.AddSeconds(this.Date);
            }

            set
            {
                var baseDate = new DateTime(1970, 1, 1);
                this.Date = (int)(value - baseDate).TotalSeconds;
            }
        }
    }
}
