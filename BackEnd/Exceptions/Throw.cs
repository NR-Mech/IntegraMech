namespace Mech.Code.Exceptions;

public static class Throw
{
    public const string DE000 = "Especialidade não encontrada.";

    public static void Now(this string message)
    {
        throw new DomainException(message);
    }
}
