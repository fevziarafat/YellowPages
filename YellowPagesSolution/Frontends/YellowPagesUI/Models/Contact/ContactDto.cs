using YellowPagesUI.Models.PhoneInformation;

namespace YellowPagesUI.Models.Contact;

public class ContactDto
{
    public ContactDto()
    {
        eMailInformations = new HashSet<EMailInformations.EMailInformationDto>();
        locationInformations = new HashSet<LocationInformationDto>();
        phoneInformations = new HashSet<PhoneInformationDto>();
    }

    public string id { get; set; }
    public string name { get; set; }
    public string surName { get; set; }
    public string firm { get; set; }

    public virtual ICollection<EMailInformations.EMailInformationDto> eMailInformations { get; set; }
    public virtual ICollection<LocationInformationDto> locationInformations { get; set; }
    public virtual ICollection<PhoneInformationDto> phoneInformations { get; set; }
}