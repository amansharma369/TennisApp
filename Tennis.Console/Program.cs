using Tennis.Domain.Services;


public class Program
{
    public static void Main(string[] args)
    {
        var engine = new TennisScoringEngine();
        while (true)
        {
            engine.RecordPoint();
        }
        
    }
}