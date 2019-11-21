﻿// -------------------------------------------------------
// © Kaplas. Licensed under MIT. See LICENSE for details.
// -------------------------------------------------------
namespace ParTool
{
    using System;
    using System.IO;
    using ParLibrary;
    using ParLibrary.Converter;
    using Yarhl.FileSystem;

    /// <summary>
    /// List contents functionality.
    /// </summary>
    internal static partial class Program
    {
        private static void List(Options.List opts)
        {
            WriteHeader();

            if (!File.Exists(opts.ParArchivePath))
            {
                Console.WriteLine($"ERROR: \"{opts.ParArchivePath}\" not found!!!!");
                return;
            }

            var parameters = new ParArchiveReaderParameters
            {
                Recursive = opts.Recursive,
            };

            using Node par = ParLibrary.NodeFactory.FromFile(opts.ParArchivePath);
            par.TransformWith<ParArchiveReader, ParArchiveReaderParameters>(parameters);

            foreach (Node node in Navigator.IterateNodes(par))
            {
                var file = node.GetFormatAs<ParFile>();
                if (file != null)
                {
                    Console.WriteLine($"{node.Path}\t{file.DecompressedSize} bytes\t{file.FileDate:G}");
                }
            }
        }
    }
}
