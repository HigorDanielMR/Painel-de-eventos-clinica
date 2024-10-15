namespace WebApi;

public class ResultErrorApi
{
    public string Descricao { get; set; }

    public List<string> Erros { get; set; } = new List<string>();

    public void AddError(string error)
    {

        Erros.Add(error);
    }
}

