// See https://aka.ms/new-console-template for more information
var beer = new BeerData();
beer.AddBeer("Corona");
beer.AddBeer("Heineken");
beer.AddBeer("Modelo");
//beer.SaveReport("beers.txt");
ReporGeneratorBeer reportGenerator = new ReporGeneratorBeer(beer);
ReportSaver reportSaver = new ReportSaver(reportGenerator);
//reportSaver.SaveReport("beers.txt");
ReporGeneratorHtml reportGeneratorhtml = new ReporGeneratorHtml(beer);
ReportSaver reportSaverhtml = new ReportSaver(reportGeneratorhtml);
//reportSaverhtml.SaveReport("beershtml.txt");

//var limitbeer = new LimitedBeerData(2);
//limitbeer.AddBeer("Corona");
//limitbeer.AddBeer("Heineken");
//limitbeer.AddBeer("Modelo");
Show(reportGenerator);
//Show(reportGeneratorhtml);

void Show (IShow reportGenerator)
{
    reportGenerator.show();
};

public interface IBeerRepostiry<T>
{
    void AddBeer(T name);
    List<T> GetBeers();
}

public class BeerData : IBeerRepostiry<string>
{
    protected List<string> _beers;
    public BeerData()
    {
        _beers = new List<string>();
    }
    public virtual void AddBeer(string name)
    {
        _beers.Add(name);
    }
    public List<string> GetBeers() => _beers;

    //public List<string> GetReport() { 
    //    var data= new List<string>();
    //    foreach (var beer in _beers)
    //    {
    //        data.Add($"Beer: {beer}");
    //    }
    //    return data;
    //}
    //public void SaveReport(string filePath)
    //{
    //    var data = GetReport();
    //    System.IO.File.WriteAllLines(filePath, data);
    //}
}

public class  LimitedBeerData: BeerData
{
    private int _limit;
    public LimitedBeerData(int limit):base()
    {
        _limit = limit;
    }
    public override void AddBeer(string name)
    {
        if (_beers.Count >= _limit)
        {
            throw new InvalidOperationException("Limit reached");
        }
        base.AddBeer(name);
    }

}

public interface IReporGenerator
{
    List<string> GetReport();
}
public interface IShow
{
    void show();
}

public class ReporGeneratorBeer : IReporGenerator, IShow
{
    private IBeerRepostiry<string> _beer;
    public ReporGeneratorBeer(IBeerRepostiry<string> beer)
    {
        _beer = beer;
    }
    public List<string> GetReport()
    {
        var data = new List<string>();
        foreach (var beer in _beer.GetBeers())
        {
            data.Add($"Beer: {beer}");
        }
        return data;
    }
    public void show()
    {
        foreach (var beer in _beer.GetBeers())
        {
            Console.WriteLine(beer);
        }
    }
}
public class ReporGeneratorHtml : IReporGenerator
{
    private IBeerRepostiry<string> _beer;
    public ReporGeneratorHtml(IBeerRepostiry<string> beer)
    {
        _beer = beer;
    }
    public List<string> GetReport()
    {
        var data = new List<string>();
        data.Add("<html><body><h1>Beers</h1><ul>");
        foreach (var beer in _beer.GetBeers())
        {
            data.Add($"<li>{beer}</li>");
        }
        data.Add("</ul></body></html>");
        return data;
    }

}

public interface IReportSaver
{
    void SaveReport(string filePath);
}

public class ReportSaver : IReportSaver
{
    private IReporGenerator _reportGenerator;
    public ReportSaver(IReporGenerator reportGenerator)
    {
        _reportGenerator = reportGenerator;
    }
    public void SaveReport(string filePath)
    {
        var data = _reportGenerator.GetReport();
        System.IO.File.WriteAllLines(filePath, data);
    }
}