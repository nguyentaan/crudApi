public class Crud
{
    public int Id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? email { get; set; }
    public string? dob { get; set; }
    public string? gender { get; set; }
    public string? education { get; set; }
    public string? company { get; set; }
    public int experience { get; set; }
    public int package { get; set; }

    internal object FirstOrDefault(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}