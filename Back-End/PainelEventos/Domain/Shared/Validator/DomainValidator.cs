using Domain.Shared.Exceptions;

namespace Domain.Shared.Validator;

public class DomainValidator
{
    private List<string> erros;

    private DomainValidator()
    {
        erros = new List<string>();
    }

    public static DomainValidator Istanciar()
     => new DomainValidator();

    public void Validar(Func<bool> validar, string mensagemErro)
    {
        if (validar() == false)
            erros.Add(mensagemErro);
    }

    public void ValidarStringVaziaOuNula(string valor, string mensagemErro)
    {
        if (string.IsNullOrEmpty(valor) || string.IsNullOrWhiteSpace(valor))
            erros.Add(mensagemErro);
    }

    public bool PossuiErro()
    {
        return erros.Count > 0;
    }

    public List<string> ObterErros()
    {
        return erros;
    }

    public void ThrowSePossuiErro()
    {
        if (PossuiErro())
            throw new DomainInvalidException(ObterErros());
    }
}
