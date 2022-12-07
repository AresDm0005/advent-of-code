namespace Solutions;

public static class Day7
{
    public static readonly string InputFile = "Day7-1.txt";

    public static long FirstStar()
    {
        var input = File.ReadAllLines(InputFinder.GetInputPath(InputFile))
            .ToList();

        var fileTree = new FileTree();
        ExecuteCommands(input, fileTree);

        return fileTree.Rc();
    }

    public static long SecondStar()
    {
        var input = File.ReadAllLines(InputFinder.GetInputPath(InputFile))
            .ToList();

        var fileTree = new FileTree();
        ExecuteCommands(input, fileTree);

        fileTree.Rc();

        return fileTree.FindSmallest();
    }

    private static void ExecuteCommands(List<string> input, FileTree fileTree)
    {
        var index = 0;
        bool ls = false;
        var lsFiles = new List<string>();
        while (index < input.Count)
        {
            if (input[index][0] == '$')
            {
                if (ls)
                {
                    fileTree.Ls(lsFiles);
                    lsFiles = new List<string>();
                    ls = false;
                    continue;
                }

                var cmd = input[index].Split();
                switch (cmd[1])
                {
                    case "cd":
                        fileTree.Cd(cmd[2]);
                        break;
                    case "ls":
                        ls = true;
                        break;
                    default:
                        break;
                }

                index++;
                continue;
            }

            lsFiles.Add(input[index]);
            index++;
        }

        if (ls)
        {
            fileTree.Ls(lsFiles);
            lsFiles = null;
        }
    }

    public class FileTree
    {
        public enum FileType
        {
            File,
            Directory
        }

        public class Node
        {
            public string Name { get; set; }
            public FileType Type { get; set; }
            public Node? Parent { get; set; }
            public List<Node> Files { get; set; }
            public long Size { get; set; }

            // Dir
            public Node(string name)
            {
                Name = name;
                Type = FileType.Directory;
                Files = new();
                Size = 0;
            }

            // File
            public Node(string name, long size)
            {
                Name = name;
                Type = FileType.File;
                Files = new();
                Size = size;
            }
        }

        public Node Root { get; }
        public Node Cursor { get; private set; }

        public FileTree()
        {
            Root = new("/");
            Cursor = Root;
        }

        public void Cd(string dir)
        {
            if (dir.Equals("/"))
            {
                Cursor = Root;
                return;
            }
            
            if (dir.Equals(".."))
            {
                if (Cursor.Parent is null)
                    throw new InvalidOperationException();

                Cursor = Cursor.Parent;
                return;
            }

            var node = Cursor.Files
                .FirstOrDefault(x => x.Type == FileType.Directory && x.Name.Equals(dir));

            if (node is null)
                throw new InvalidOperationException();

            Cursor = node;
        }

        public void Ls(List<string> items)
        {
            foreach (var item in items)
            {
                var spl = item.Split();

                if (spl[0].Equals("dir"))
                {
                    var dir = new Node(spl[1]);
                    dir.Parent = Cursor;
                    Cursor.Files.Add(dir);
                    continue;
                }

                var size = int.Parse(spl[0]);
                var file = new Node(spl[1], size);
                file.Parent = Cursor;
                Cursor.Files.Add(file);
            }
        }

        public long Rc()
        {
            return Sizes(Root);
        }

        private long Sizes(Node node)
        {
            var dirs = node.Files.Where(x => x.Type == FileType.Directory).ToList();

            var childSizes = 0L;
            if (dirs.Count > 0)
                childSizes = dirs.Sum(x => Sizes(x));

            var size = node.Files.Sum(x => x.Size);
            node.Size = size;
            return childSizes + (node.Size <= 100000 ? node.Size : 0);
        }

        public long FindSmallest()
        {
            const long totalSpace = 70_000_000;
            var unusedSpace = totalSpace - Root.Size;
            var spaceToClear = 30_000_000 - unusedSpace;

            var bigSizes = new List<long>();
            if (Root.Size >= spaceToClear) bigSizes.Add(Root.Size);
            CheckDirSize(Root, spaceToClear, bigSizes);

            return bigSizes.DefaultIfEmpty(0).Min();
        }

        private void CheckDirSize(Node node, long toClear, List<long> bigSizes)
        {
            var dirs = node.Files.Where(x => x.Type == FileType.Directory).ToList();

            foreach (var dir in dirs)
            {
                if (dir.Size >= toClear) bigSizes.Add(dir.Size);

                CheckDirSize(dir, toClear, bigSizes);
            }
        }
    }
}
