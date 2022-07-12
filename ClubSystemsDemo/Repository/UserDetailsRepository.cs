using AutoMapper;
using ClubSystemsTest.DbContexts;
using ClubSystemsTest.Models;
using ClubSystemsTest.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ClubSystemsTest.Repository
{
    public class UserDetailsRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public UserDetailsRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDetailsDto>> GetUserDetails()
        {
            List<UserDetails> userList = await _db.UserDetails.ToListAsync();
            return _mapper.Map<List<UserDetailsDto>>(userList);
        }

        public async Task<UserDetailsDto> GetUserDetailsById(int personID)
        {
            UserDetails userDetails = await _db.UserDetails.Where(x => x.PersonID == personID).FirstOrDefaultAsync();
            return _mapper.Map<UserDetailsDto>(userDetails);
        }


        public async Task<UserDetailsDto> CreateUpdateUserDetails(UserDetailsDto userDetailsDto)
        {
            UserDetails userDetails = _mapper.Map<UserDetailsDto, UserDetails>(userDetailsDto);
            if (userDetails.PersonID > 0)
            {
                _db.UserDetails.Update(userDetails);
            }
            else
            {
                _db.UserDetails.Add(userDetails);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<UserDetails, UserDetailsDto>(userDetails);
        }
    }
}
