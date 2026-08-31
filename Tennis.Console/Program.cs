using Tennis.Domain.Services;


public class Program
{
    public static void Main(string[] args)
    {
        var engine = new TennisScoringEngine();
        
        for (int i = 0; i < 4; i++) engine.RecordPoint(1); // 1-0
for (int i = 0; i < 4; i++) engine.RecordPoint(2); // 1-1

for (int i = 0; i < 4; i++) engine.RecordPoint(1); // 2-1
for (int i = 0; i < 4; i++) engine.RecordPoint(2); // 2-2

for (int i = 0; i < 4; i++) engine.RecordPoint(1); // 3-2
for (int i = 0; i < 4; i++) engine.RecordPoint(2); // 3-3

for (int i = 0; i < 4; i++) engine.RecordPoint(1); // 4-3
for (int i = 0; i < 4; i++) engine.RecordPoint(2); // 4-4

for (int i = 0; i < 4; i++) engine.RecordPoint(1); // 5-4
for (int i = 0; i < 4; i++) engine.RecordPoint(2); // 5-5

for (int i = 0; i < 4; i++) engine.RecordPoint(1); // 6-5
for (int i = 0; i < 4; i++) engine.RecordPoint(2); // 6-6
        
    }
}