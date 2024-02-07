using gRPCService.Enums;

namespace gRPCService.Services;

public class Data
{
    public string? Measurement { get; set; }
    public string? ParentID { get; set; }
    public string? ItemType { get; set; }
    public string? ItemID { get; set; }
    public string? FullName { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Dictionary<Enums.Tag, object> Tags  = new Dictionary<Enums.Tag, object>();
    public Status Status { get; set; }
    public Stage Stage { get; set; }
    public long Start { get; set; }
    public long Stop { get; set; }
    public object? Value { get; set; }
    public long Time { get; set; }

    public override string ToString()
    {
        UpdateTags(Enums.Tag.Status, Enum.GetName(typeof(Status), Status));
        UpdateTags(Enums.Tag.Stage, Enum.GetName(typeof(Stage), Stage));
        UpdateTags(Enums.Tag.ParentID, ParentID);
        UpdateTags(Enums.Tag.ItemType, ItemType);
        UpdateTags(Enums.Tag.ItemID, ItemID);
        UpdateTags(Enums.Tag.Description, Description?.Replace(" ", "_"));
        UpdateTags(Enums.Tag.FullName, FullName);
        UpdateTags(Enums.Tag.Start, Start);
        UpdateTags(Enums.Tag.Stop, Stop);


        string? _Tag = string.Join(",", Tags.Where(tag => tag.Value is not null)
                                            .Select(tag => $",{tag.Key}={tag.Value}")).Replace(",,", ",");

        if (Value is string output)
        {
            System.Console.WriteLine("Value is string : " + Value);
            Value = string.IsNullOrEmpty(output) ? "empty" : output;
            Value = $"\"{Value}\"";
        }
        string _Field = $"{Name}={Convert.ToString(Value ?? "\"\"")}";
        //string _Time = $"{Utils.ToUnixNanoSeconds(Time)}"; Time is converted from DateTime to float
        string _Time = Time.ToString();
        
        return $"{Measurement}" +
               $"{_Tag} " +
               $"{_Field} {_Time}";
    }
    private void UpdateTags(Enums.Tag tag, object? tagValue)
    {
        if (tagValue is null) return;

        if (Tags.ContainsKey(tag)) Tags[tag] = tagValue;
        else Tags.Add(tag, tagValue);
    }
}