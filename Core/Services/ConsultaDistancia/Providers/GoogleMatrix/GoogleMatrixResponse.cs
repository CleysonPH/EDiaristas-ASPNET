namespace EDiaristas.Core.Services.ConsultaDistancia.Providers.GoogleMatrix;

public partial class GoogleMatrixResponse
{
    public IList<Row> Rows { get; set; } = new List<Row>();
}

public partial class Row
{
    public IList<Element> Elements { get; set; } = new List<Element>();
}

public partial class Element
{
    public string Status { get; set; } = "NOT_FOUND";
    public Distance Distance { get; set; } = new Distance();
}

public partial class Distance
{
    public int Value { get; set; }
}