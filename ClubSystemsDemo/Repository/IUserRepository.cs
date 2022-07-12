using ClubSystemsTest.Models.Dto;

namespace ClubSystemsTest.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDetailsDto>> GetUserDetails();
        Task<UserDetailsDto> GetUserDetailsById(int personID);
        Task<UserDetailsDto> CreateUpdateUserDetails(UserDetailsDto userDetailsDto);
        //Task<bool> DeleteUserDetails(int personID);
    }
}
