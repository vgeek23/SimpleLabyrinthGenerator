namespace Maze
{
    /// <summary>
    /// Using North, East, South and West as reference to neighbour corner
    /// </summary>
    public static class MazeElements
    {
        public static readonly char allNeighbours = '\u256C';
        public static readonly char nesNeighbours = '\u2560';
        public static readonly char nswNeighbours = '\u2563';
        public static readonly char eswNeighbours = '\u2566';
        public static readonly char newNeighbours = '\u2569';
        public static readonly char ewNeighbours = '\u2550';
        public static readonly char nsNeighbours = '\u2551';
        public static readonly char esNeighbours = '\u2554';
        public static readonly char swNeighbours = '\u2557';
        public static readonly char neNeighbours = '\u255A';
        public static readonly char nwNeighbours = '\u255D';
        public static readonly char ewNeighboursEnd = '\u2550';
        public static readonly char nsNeighboursEnd = '\u2551';
        public static readonly char noNeighbours = '\u2591';
        public static readonly char walkedSteps = '\u2592';
        public static readonly char correctPath = '\u2593';
        public static readonly char floor = '\u0020';        
    }
    public enum MazeExit
    {
        HaveExit,
        HaveNotExit,
        NotSolved
    }
}
