using System;
using System.Collections.Generic;
using System.Linq;

class Query
{
    protected List<int> dataSource;
    protected bool isExecuted;

    public Query(List<int> data)
    {
        dataSource = data;
        isExecuted = false;
    }

    public virtual IEnumerable<int> Apply()
    {
        return dataSource;
    }

    public virtual List<int> Execute()
    {
        isExecuted = true;
        return Apply().ToList();
    }

    public virtual string GetQueryType()
    {
        return "Base Query";
    }
}

class FilterQuery : Query
{
    private string predicate;
    private int filteredCount;

    public FilterQuery(List<int> data, string predicate) : base(data)
    {
        this.predicate = predicate;
    }

    public override IEnumerable<int> Apply()
    {
        if (predicate == "even")
            return dataSource.Where(x => x % 2 == 0);

        if (predicate.StartsWith(">"))
        {
            int value = int.Parse(predicate.Substring(1));
            return dataSource.Where(x => x > value);
        }

        if (predicate.StartsWith("<"))
        {
            int value = int.Parse(predicate.Substring(1));
            return dataSource.Where(x => x < value);
        }

        return dataSource;
    }

    public override List<int> Execute()
    {
        var result = Apply().ToList();
        filteredCount = result.Count;
        isExecuted = true;

        Console.WriteLine($"Filter Executed,Predicate:{predicate},Result Count:{filteredCount}");
        return result;
    }

    public override string GetQueryType()
    {
        return "Filter";
    }
}

class AggregateQuery : Query
{
    private string operation;
    private double result;

    public AggregateQuery(List<int> data, string operation) : base(data)
    {
        this.operation = operation;
    }

    public override IEnumerable<int> Apply()
    {
        return dataSource;
    }

    public override List<int> Execute()
    {
        switch (operation)
        {
            case "Sum":
                result = dataSource.Sum();
                break;

            case "Average":
                result = dataSource.Average();
                break;

            case "Max":
                result = dataSource.Max();
                break;

            case "Min":
                result = dataSource.Min();
                break;
        }

        isExecuted = true;

        Console.WriteLine($"Aggregation Executed,Operation:{operation},Result:{result}");
        return dataSource;
    }

    public override string GetQueryType()
    {
        return "Aggregate";
    }
}

class Program
{
    static void Main()
    {
        string queryType = Console.ReadLine().Trim();

        List<int> data = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        string input = Console.ReadLine().Trim();

        Query query;

        if (queryType == "Filter")
        {
            query = new FilterQuery(data, input);
        }
        else
        {
            query = new AggregateQuery(data, input);
        }

        query.Execute();
    }
}