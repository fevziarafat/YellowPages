namespace YellowPagesService.Dtos;

public class YellowPagesDto
{
    public YellowPagesDto()
    {
        EMailInformations = new HashSet<EMailInformationDto>();
        LocationInformations = new HashSet<LocationInformationDto>();
        PhoneInformations = new HashSet<PhoneInformationDto>();
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Firm { get; set; }

    public virtual ICollection<EMailInformationDto> EMailInformations { get; set; }
    public virtual ICollection<LocationInformationDto> LocationInformations { get; set; }
    public virtual ICollection<PhoneInformationDto> PhoneInformations { get; set; }
}