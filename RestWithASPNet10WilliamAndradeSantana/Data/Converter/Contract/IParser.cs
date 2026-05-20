namespace RestWithASPNet10WilliamAndradeSantana.Data.Converter.Contract;

public interface IParser<O, D>
{
    D Parse(O origin);
    List<D> ParseList(List<O> origin);
}