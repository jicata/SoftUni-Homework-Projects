namespace MassDefect.Client
{
    using System.Linq;
    using Data;

    class Program
    {
        static void Main(string[] args)
        {
            MassDefectContext context = new MassDefectContext();
            context.Stars.Count();
        }
    }
}
