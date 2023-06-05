namespace YellowPagesService.Dtos;

public class YellowPagesReportDto
{
    public string Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public string Location { get; set; }
    public string State { get; set; }
    public int LocationContactCount { get; set; }
    public int LocationPhoneCount { get; set; }
}