using ClubSystemsTest.Models.Dto;

namespace ClubSystemsTest.Repository
{
    public interface IMembershipRepository
    {
        Task<IEnumerable<MembershipDetailsDto>> GetMembershipDetails();
        Task<MembershipDetailsDto> GetMembershipDetailsById(int memebershipID);
        Task<MembershipDetailsDto> CreateUpdateMembershipDetails(MembershipDetailsDto membershipDetailsDto);
    }
}
